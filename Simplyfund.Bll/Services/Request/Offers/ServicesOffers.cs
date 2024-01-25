using AutoMapper;
using Simplyfund.Bll.Services.BaseServices;
using Simplyfund.Bll.ServicesInterface.Request.Offers;
using Simplyfund.Dal.DataInterface.IBaseDatas;
using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Dto.Enums;
using SimplyFund.Domain.Dto.Request.Offers;
using SimplyFund.Domain.Models.Requests;
using SimplyFund.Domain.Models.Requests.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Requestss = SimplyFund.Domain.Models.Requests.Request;

namespace Simplyfund.Bll.Services.Request.Offers
{
    public class ServicesOffers : BaseService<OfferRequest>, IServicesOffers
    {
        IBaseDatas<OfferRequest> baseModel;
        IBaseDatas<OfferStatus> dataOfferStatus;
        IBaseDatas<OffersRequestsComment> dataOfferRequestComment;
        IBaseDatas<Requestss> dataRequestss;
        IBaseDatas<RequestStatus> dataRequestStatus;
        IMapper mapper;
        public ServicesOffers(IBaseDatas<OfferRequest> baseModel, IMapper mapper, IBaseDatas<OfferStatus> dataOfferStatus, IBaseDatas<OffersRequestsComment> dataOfferRequestCommentDto, IBaseDatas<Requestss> dataRequestss, IBaseDatas<RequestStatus> dataRequestStatus) : base(baseModel)
        {
            this.baseModel = baseModel;
            this.mapper = mapper;
            this.dataOfferStatus = dataOfferStatus;
            this.dataOfferRequestComment = dataOfferRequestCommentDto;
            this.dataRequestss = dataRequestss;
            this.dataRequestStatus = dataRequestStatus;
        }

        public async Task<List<OfferRequestDto>> GetOffersByRequestId(int requestId)
        {
            try
            {

                var offerstatusDelete = await dataOfferStatus.GetAsync(x => x.Description == offersStatusEnum.Eliminada);
                if (offerstatusDelete != null)
                {


                    var offers = await baseModel.GetManyAsync(x => x.RequestId == requestId && x.OffersStatusId != offerstatusDelete.Id);

                    var map = mapper.Map<List<OfferRequestDto>>(offers);


                    var offersList = new List<OfferRequestDto>();

                    foreach (var item in map)
                    {
                        if (item != null)
                        {
                            var offerstatus = await dataOfferStatus.GetAsync(x => x.Description == offersStatusEnum.Devuelta);
                            if (offerstatus != null)
                            {
                                if (item.OffersStatusId == offerstatus.Id)
                                {
                                    var comment = await dataOfferRequestComment.GetManyAsync(x => x.OfferRequestId == item.Id);
                                    if (comment != null)
                                    {
                                        item.OfferComments = comment;
                                    }
                                }
                            }

                            offersList.Add(item);
                        }
                    }


                    return offersList;
                }
                else
                {
                    throw new Exception("Estatus Eliminado no existe verificar.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override async Task<bool> UpdateAsync(OfferRequest entity)
        {
            try
            {
                var offer = await baseModel.GetAsync(x => x.Id == entity.Id);
                if (offer != null)
                {
                    if (offer.InvestorId == entity.InvestorId)
                    {

                        var statusOffer = await dataOfferStatus.GetAsync(x => x.Id == offer.OffersStatusId);
                        if (statusOffer != null)
                        {
                            if (statusOffer.Description == offersStatusEnum.Devuelta)
                            {
                                return await baseModel.UpdateAsync(offer);
                            }
                            else
                            {
                                throw new Exception($"Oferta se encuentra en estatus {statusOffer.Description}, no se puede completar accion.");
                            }
                        }
                        else
                        {
                            throw new Exception("No existe el estatus de la oferta");
                        }
                    }
                    else
                    {
                        throw new Exception("Oferta solo puede ser editada por el inversionista.");
                    }

                }
                else
                {
                    throw new Exception("Oferta no encontrada.");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public override async Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                var offer = await baseModel.GetAsync(x => x.Id == id);
                if (offer != null)
                {
                    var statusOffer = await dataOfferStatus.GetAsync(x => x.Id == offer.OffersStatusId);
                    if (statusOffer != null)
                    {
                        if (statusOffer.Description == offersStatusEnum.Pendiente)
                        {
                            var statusDelete = await dataOfferStatus.GetAsync(x => x.Description == offersStatusEnum.Eliminada);
                            if (statusDelete != null)
                            {
                                offer.OffersStatusId = statusDelete.Id;
                                return await baseModel.UpdateAsync(offer);
                            }
                            else
                            {
                                throw new Exception("No existe el estatus para poder eliminar esta oferta.");
                            }

                        }
                        else
                        {
                            throw new Exception($"Oferta se encuentra en estatus {statusOffer.Description}, no se puede completar accion.");
                        }
                    }
                    else
                    {
                        throw new Exception("No existe el estatus de la oferta");
                    }

                }
                else
                {
                    throw new Exception("No existe esta oferta.");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> RejectInvesmentOffer(int id)
        {
            try
            {
                var statusReject = await dataOfferStatus.GetAsync(x => x.Description == offersStatusEnum.Rechazada);
                if (statusReject != null)
                {
                    var offer = await baseModel.GetAsync(x => x.Id == id);
                    if (offer != null)
                    {
                        var statusOffer = await dataOfferStatus.GetAsync(x => x.Id == offer.OffersStatusId);
                        if (statusOffer != null)
                        {
                            if (statusOffer.Description == offersStatusEnum.Pendiente)
                            {
                                offer.OffersStatusId = statusReject.Id;
                                var result = await baseModel.UpdateAsync(offer);

                                return result;
                            }
                            else
                            {
                                throw new Exception($"Oferta no esta disponible para realizar esta accion estatus {statusOffer.Description}");
                            }
                        }
                        else
                        {
                            throw new Exception("Estatus de la offerta no esta valido");
                        }
                    }
                    else
                    {
                        throw new Exception("No existe esta oferta.");
                    }
                }
                else
                {
                    throw new Exception("No existe la este estatus configurado");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Counteroffer(OffersRequestsCommentDto offerRequestCommentDto)
        {
            try
            {

                var offer = await baseModel.GetAsync(x => x.Id == offerRequestCommentDto.OfferRequestId);
                if (offer != null)
                {
                    var offerstatus = await dataOfferStatus.GetAsync(x => x.Description == offersStatusEnum.Devuelta);

                    if (offerstatus != null)
                    {
                        if (offer.OffersStatusId != offerstatus.Id)
                        {

                            var map = mapper.Map<OffersRequestsComment>(offerRequestCommentDto);
                            await dataOfferRequestComment.AddAsync(map);


                            offer.OffersStatusId = offerstatus.Id;

                            await baseModel.UpdateAsync(offer);

                            return true;
                        }
                        else
                        {
                            throw new Exception("No es posible realizar contraoferta por que el estatus no lo permite.");
                        }

                    }
                    else
                    {
                        throw new Exception("Estatus no encontrado");
                    }
                }
                else
                {
                    throw new Exception("Offerta no encontrada.");
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Acceptoffer(ValidateOffer validateOffer)
        {
            try
            {
                var offer = await baseModel.GetAsync(x => x.Id == validateOffer.OfferId);

                if (offer != null)
                {
                    var offerstatus = await dataOfferStatus.GetAsync(x => x.Id == offer.OffersStatusId);

                    if (offerstatus != null)
                    {
                        var validateStatusOffer = offerstatus.Description == offersStatusEnum.Aprobada || offerstatus.Description == offersStatusEnum.Rechazada || offerstatus.Description == offersStatusEnum.Eliminada;
                        if (!validateStatusOffer)
                        {
                            var statusAccept = await dataOfferStatus.GetAsync(x => x.Description == offersStatusEnum.Aprobada);
                            if (statusAccept != null)
                            {
                                if (offer.Requests != null)
                                {
                                    if (offer.Requests.CustomerId == validateOffer.UserId)
                                    {
                                        offer.LastUpdate = DateTime.UtcNow;
                                        offer.OffersStatusId = statusAccept.Id;
                                        await baseModel.UpdateAsync(offer);
                                        return true;
                                    }
                                    else
                                    {
                                        throw new Exception("Solo el customer puede aceptar esta offerta.");
                                    }

                                }
                                else
                                {
                                    throw new Exception("Error validando el customer de esta offerta.");
                                }

                            }
                            else
                            {
                                throw new Exception("No existe el estatus para aceptado.");
                            }
                        }
                        else
                        {
                            throw new Exception($"Offerta no puede completar accion se encuentra estatus {offerstatus.Description}");
                        }
                    }
                    else
                    {
                        throw new Exception("El estatus de esta oferta no existe.");
                    }

                }
                else
                {
                    throw new Exception("Oferta no existe, enviar una oferta que sea valida.");
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Rejectoffer(ValidateOffer validateOffer)
        {
            try
            {
                var offer = await baseModel.GetAsync(x => x.Id == validateOffer.OfferId);

                if (offer != null)
                {
                    var offerstatus = await dataOfferStatus.GetAsync(x => x.Id == offer.OffersStatusId);

                    if (offerstatus != null)
                    {
                        var validateStatusOffer = offerstatus.Description == offersStatusEnum.Aprobada || offerstatus.Description == offersStatusEnum.Rechazada || offerstatus.Description == offersStatusEnum.Eliminada;
                        if (!validateStatusOffer)
                        {
                            var statusAccept = await dataOfferStatus.GetAsync(x => x.Description == offersStatusEnum.Rechazada);
                            if (statusAccept != null)
                            {
                                if (offer.Requests != null)
                                {
                                    if (offer.Requests.CustomerId == validateOffer.UserId)
                                    {
                                        offer.LastUpdate = DateTime.UtcNow;

                                        offer.OffersStatusId = statusAccept.Id;
                                        await baseModel.UpdateAsync(offer);


                                        if (validateOffer.Comment != null)
                                        {
                                            var offerComment = new OffersRequestsComment()
                                            {
                                                OfferRequestId = offer.Id,
                                                Commnet = validateOffer.Comment
                                            };

                                            await dataOfferRequestComment.AddAsync(offerComment);
                                        }


                                        return true;
                                    }
                                    else
                                    {
                                        throw new Exception("Solo el customer puede aceptar esta offerta.");
                                    }

                                }
                                else
                                {
                                    throw new Exception("Error validando el customer de esta offerta.");
                                }

                            }
                            else
                            {
                                throw new Exception("No existe el estatus para aceptado.");
                            }
                        }
                        else
                        {
                            throw new Exception($"Offerta no puede completar accion se encuentra estatus {offerstatus.Description}");
                        }
                    }
                    else
                    {
                        throw new Exception("El estatus de esta oferta no existe.");
                    }

                }
                else
                {
                    throw new Exception("Oferta no existe, enviar una oferta que sea valida.");
                }


            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<List<GroupOffersDto>> GetCommonOffers(int RequestId, int userId)
        {
            try
            {
                var request = await dataRequestss.GetAsync(x => x.Id == RequestId);
                if (request != null)
                {
                    var requestStatus = await dataRequestStatus.GetAsync(x => x.Id == request.RequestStatusId);
                    if (requestStatus != null)
                    {
                        if (requestStatus.Name != RequestEstatusEnum.marketplace)
                        {

                            var offerts = await baseModel.GetManyAsync(x => x.RequestId == RequestId && x.OffersStatusId == 2);
                            if (offerts != null)
                            {

                                List<GroupOffersDto> groupOffers = new List<GroupOffersDto>();

                                var groupedOffers = offerts.GroupBy(item => new { item.Quotas, item.AnnualInterest, item.OffersRequestsPeriodsId });

                                foreach (var group in groupedOffers)
                                {
                                    if (group.Count() > 1)
                                    {


                                        GroupOffersDto groupOffersDto = new GroupOffersDto();

                                        groupOffersDto.Quotas = group.Key.Quotas;
                                        groupOffersDto.Interest = group.Key.AnnualInterest;
                                        groupOffersDto.Period = group.Key.OffersRequestsPeriodsId;

                                        List<OfferRequest>? Offers = new List<OfferRequest>();
                                        foreach (var item in group)
                                        {
                                            OfferRequest offerDto = new OfferRequest
                                            {

                                                Amount = item.Amount,
                                                Id = item.Id
                                            };
                                            Offers.Add(offerDto);

                                        }
                                        groupOffersDto.Offers = Offers;
                                        groupOffers.Add(groupOffersDto);
                                    }
                                }


                                return groupOffers;
                            }
                            else
                            {
                                throw new Exception("No se encontraron ofertas pendientes para esta solicitud.");
                            }


                        }
                        else
                        {
                            throw new Exception("Solicitud no se encuentra en marketplace, no se puede completar accion.");
                        }

                    }
                    else
                    {
                        throw new Exception("El estatus de esta oferta no existe es invalido.");
                    }
                }
                else
                {
                    throw new Exception("No existe esta solicitud");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        //public async Task<object> GroupOffersAccept(List<int> offers)
        //{

        //}

    }
}
