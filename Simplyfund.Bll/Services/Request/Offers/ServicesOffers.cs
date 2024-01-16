using AutoMapper;
using Simplyfund.Bll.Services.BaseServices;
using Simplyfund.Bll.ServicesInterface.Request.Offers;
using Simplyfund.Dal.DataInterface.IBaseDatas;
using SimplyFund.Domain.Dto.Enums;
using SimplyFund.Domain.Dto.Request.Offers;
using SimplyFund.Domain.Models.Requests.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.Services.Request.Offers
{
    public class ServicesOffers : BaseService<OfferRequest>, IServicesOffers
    {
        IBaseDatas<OfferRequest> baseModel;
        IBaseDatas<OfferStatus> dataOfferStatus;
        IBaseDatas<OffersRequestsComment> dataOfferRequestComment;
        IMapper mapper;
        public ServicesOffers(IBaseDatas<OfferRequest> baseModel, IMapper mapper, IBaseDatas<OfferStatus> dataOfferStatus, IBaseDatas<OffersRequestsComment> dataOfferRequestCommentDto) : base(baseModel)
        {
            this.baseModel = baseModel;
            this.mapper = mapper;
            this.dataOfferStatus = dataOfferStatus;
            this.dataOfferRequestComment = dataOfferRequestCommentDto;
        }

        public async Task<List<OfferRequestDto>> GetOffersByRequestId(int requestId)
        {
            try
            {
                var offers = await baseModel.GetManyAsync(x => x.RequestId == requestId);

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


    }
}
