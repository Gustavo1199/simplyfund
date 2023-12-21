using Simplyfund.Bll.Services.BaseServices;
using Simplyfund.Bll.ServicesInterface.Request.Offers.AddedOffers;
using Simplyfund.Dal.DataInterface.IBaseDatas;
using SimplyFund.Domain.Dto.Enums;
using SimplyFund.Domain.Models.Requests.Offers;
using SimplyFund.Domain.Models.Requests.Offers.AddedOffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Simplyfund.Bll.Services.Request.Offers.AddedOffers
{
    public class ServicesAddedOffers : BaseService<AddedOffer>, IServicesAddedOffers
    {
        IBaseDatas<AddedOffer> baseModel;
        IBaseDatas<OfferRequest> dataOffer;
        IBaseDatas<OfferStatus> dataOfferStatus;
        IBaseDatas<OfferType> dataOfferType;

        public ServicesAddedOffers(IBaseDatas<AddedOffer> baseModel, IBaseDatas<OfferRequest> dataOffer, IBaseDatas<OfferStatus> dataOfferStatus, IBaseDatas<OfferType> dataOfferType) : base(baseModel)
        {
            this.baseModel = baseModel;
            this.dataOffer = dataOffer;
            this.dataOfferStatus = dataOfferStatus;
            this.dataOfferType = dataOfferType;
        }


        public override async Task<AddedOffer> AddAndReturnAsync(AddedOffer entity)
        {
            try
            {
                var offer = await dataOffer.GetAsync(x => x.Id == entity.OfferRequestId);
                if (offer != null)
                {
                    var statusOffer = await dataOfferStatus.GetAsync(x => x.Id == offer.OffersStatusId);
                    if (statusOffer != null)
                    {
                        var offerType = await dataOfferType.GetAsync(x=>x.Id == offer.OffersTypesId);
                        if (offerType != null)
                        {

                            if (statusOffer.Description == offersStatusEnum.Aprobada && offerType.Description == OfferTypeEnum.Parcial)
                            {
             
                                return await baseModel.AddAndReturnAsync(entity);
                            }
                            else
                            {
                                throw new Exception($"Oferta se encuentra en estatus {statusOffer.Description}, no se puede completar accion.");
                            }
                        }
                        else
                        {
                            throw new Exception("El tipo de offerta esta null");
                        }
                    }
                    else
                    {
                        throw new Exception("No existe el estatus de la oferta");
                    }

                }
                else
                {
                    throw new Exception("Oferta no existe favor verificar.");
                }

            
            }
            catch (Exception)
            {

                throw;
            }
            
        }




    }


}
