using AutoMapper;
using Simplyfund.Bll.Services.BaseServices;
using Simplyfund.Bll.ServicesInterface.Requests;
using Simplyfund.Dal.DataInterface.IBaseDatas;
using SimplyFund.Domain.Base.Filter;
using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Dto.Enums;
using SimplyFund.Domain.Dto.File;
using SimplyFund.Domain.Dto.Request;
using SimplyFund.Domain.Models.Common;
using SimplyFund.Domain.Models.Requests;
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
        IMapper mapper;
        public ServicesRequest(IBaseDatas<request1> baseModel, IMapper mapper, IBaseDatas<File> baseFile, IBaseDatas<Document> baseDocumento, IBaseDatas<EntityType> baseEntityType) : base(baseModel)
        {
            this.baseModel = baseModel;
            this.mapper = mapper;
            this.baseFile = baseFile;
            this.baseDocumento = baseDocumento;
            this.baseEntityType = baseEntityType;
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

        public async Task<RequestDatailsDto> GetByIdDetailsAsync(int id)
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




    }
}
