using AutoMapper;
using Microsoft.AspNetCore.Http;
using Simplyfund.Bll.Services.BaseServices;
using Simplyfund.Bll.ServicesInterface.Requests;
using Simplyfund.Dal.DataInterface.IBaseDatas;
using Simplyfund.Dal.Rabbit;
using SimplyFund.Domain.Base.Filter;
using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Dto.Enums;
using SimplyFund.Domain.Dto.File;
using SimplyFund.Domain.Dto.Request;
using SimplyFund.Domain.Models.Common;
using SimplyFund.Domain.Models.RabbitMQ;
using SimplyFund.Domain.Models.Requests;
using System.Collections.Generic;
using Document = SimplyFund.Domain.Models.Common.Document;
using File = SimplyFund.Domain.Models.Common.File;
using request1 = SimplyFund.Domain.Models.Requests.Request;

namespace Simplyfund.Bll.Services.Requests
{
    public class ServicesRequest : BaseService<request1>, IServicesRequest
    {
        IBaseDatas<request1> baseModel;
        IBaseDatas<File> baseFile;
        IBaseDatas<Document> baseDocumento;
        IBaseDatas<EntityType> baseEntityType;
        IBaseDatas<RequestStatus> baseRequestStatus;
        IBaseDatas<RequestExpenseRelation> baseRequestExpenseRelation;
        IMapper mapper;
        IRabitMQProducer rabitMQProducer;

        public ServicesRequest(IBaseDatas<request1> baseModel, IMapper mapper, IBaseDatas<File> baseFile, IBaseDatas<Document> baseDocumento, IBaseDatas<EntityType> baseEntityType, IRabitMQProducer rabitMQProducer, IBaseDatas<RequestStatus> baseRequestStatus, IBaseDatas<RequestExpenseRelation> baseRequestExpenseRelation) : base(baseModel)
        {
            this.baseModel = baseModel;
            this.mapper = mapper;
            this.baseFile = baseFile;
            this.baseDocumento = baseDocumento;
            this.baseEntityType = baseEntityType;
            this.rabitMQProducer = rabitMQProducer;
            this.baseRequestStatus = baseRequestStatus;
            this.baseRequestExpenseRelation = baseRequestExpenseRelation;
        }

        public async Task<PaginatedList<RequestDto>?> RequestLists(FilterAndPaginateRequestModel? filters)
        {
            try
            {

                if (filters != null)
                {
                    var requests = await baseModel.FilterAndPaginateAsync(filters);
                    if (requests != null)
                    {


                        var document = await baseDocumento.GetAsync(x=>x.Description == DocumentEnum.Imagene_solicitud);

                        if (document != null)
                        {

                            List<RequestDto> requestDtos = new List<RequestDto>();

                            var map = mapper.Map<List<RequestDto>>(requests.Items);


                            foreach (var item in map)
                            {

                                var filesdto = await baseFile.GetManyAsync(x => x.DocumentId == document.Id && x.EntityId == item.Id);

                                var mapFile = mapper.Map<List<FileDto>>(filesdto);

                                item.WarrantyFiles = mapFile;

                                requestDtos.Add(item);
                            }



                            PaginatedList<RequestDto> paginated = new PaginatedList<RequestDto>(requestDtos, requests.TotalPages, requests.PageIndex, filters.PageSize);

                            return paginated;

                        }
                        else
                        {
                            throw new Exception("Documento no encontrado");
                        }
                    }
                    else
                    {
                        return null;
                    }



                }
                else
                {

                    throw new Exception("Filtro no pueden estar null");

                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<RequestDatailsDto> GetByIdDetailsAsync(int id, int? userId)
        {
            try
            {
                var search = await baseModel.GetByIdAsync(id);
                if (search != null)
                {

                  var entityType = await baseEntityType.GetAsync(x=>x.Name == EntityTypesEnum.RequestWarranty);
                    if (entityType != null)
                    {


                        var filesdto = await baseFile.GetManyAsync(x => x.EntityTypeId == entityType.Id && x.EntityId == id);

                        var mapFile = mapper.Map<List<FileDto>>(filesdto);


                        var map = mapper.Map<RequestDatailsDto>(search);

                        map.WarrantyFiles = mapFile;

                        if (userId.HasValue)
                        {
                            if (map.CustomerId == userId)
                            {
                                var expenses = await baseRequestExpenseRelation.GetManyAsync(x=>x.RequestID == map.Id);
                                if (expenses != null)
                                {
                                    map.Expenses = expenses.ToList();

                                }
                            }
                        }
                        




                        return map;
                    }
                    else
                    {
                        throw new Exception("Estatus no encontrado.");
                    }

                }
                else
                {
                    throw new Exception("Solicitud no encontrada.");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public override async Task<request1> AddAndReturnAsync(request1 entity)
        {

            try
            {
                if (entity != null)
                {


                    var statusRequest = await baseRequestStatus.GetAsync(x => x.Name == RequestEstatusEnum.revisión);
                    if (statusRequest != null)
                    {
                        entity.RequestStatusId = statusRequest.Id;
                    }
                    if (entity.Files != null)
                    {
                        var file = entity.Files;

                        var expenses = entity.RequestExpenses;

                        var addRequest = await baseModel.AddAndReturnAsync(entity);

                        List<FileDto> fileDtos = new List<FileDto>();
                        foreach (var item in file)
                        {
                            item.EntityId = addRequest.Id;
                            fileDtos.Add(item);
                        }

                        UploadManyDocument(fileDtos);

                        if (expenses != null)
                        {
                            foreach (var item in expenses)
                            {
                                item.RequestID = addRequest.Id;
                                await baseRequestExpenseRelation.AddAsync(item);
                            }
                           
                        }

                        return addRequest;

                    }
                    else
                    {
                        throw new Exception("Es necesario que suba los archivos con la solicitud.");
                    }

                }
                else
                {
                    throw new Exception("Modelo no puede ser null.");
                }

            }
            catch (Exception)
            {

                throw;
            }
           
        }


        public override async Task<request1> UpdateAndReturnAsync(request1 entity)
        {
            return await base.UpdateAndReturnAsync(entity);
        }

        public void UploadManyDocument(List<FileDto> fileDtos)
        {

            try
            {
                List<FileDto> fileDatosList = new List<FileDto>();

                foreach (var file in fileDtos)
                {
                    if (file.File != null)
                    {
                        file.Content = ConvertIFormFileToByteArray(file.File);
                        file.FileType = file.File.ContentType;
                        file.FileName = file.File.FileName;
                        file.ContentDisposition = file.File.ContentDisposition;
                        fileDatosList.Add(file);
                    }
                }

                RequestRabbitMQ requestRabbitMQ = new RequestRabbitMQ();
                requestRabbitMQ.queue = "fileQueue";
                requestRabbitMQ.message = fileDatosList;
                requestRabbitMQ.exchange = "fileExchange";
                requestRabbitMQ.routingkey = "file.routing.key";

                rabitMQProducer.SendProductMessage(requestRabbitMQ);


            }
            catch (Exception)
            {

                throw;
            }

        }


        public byte[] ConvertIFormFileToByteArray(IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

    }
}
