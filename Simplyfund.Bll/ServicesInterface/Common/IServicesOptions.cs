using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.ServicesInterface.Common
{
    public interface IServicesOptions
    {
        Task<List<OptionsResponses>> GetCountry();
        Task<List<OptionsResponses>> GetProvince();
        Task<List<OptionsResponses>> GetCustomerTypes();

        Task<List<OptionsResponses>> GetIdentityTypeData();

        Task<List<OptionsResponses>> GetCategories();

        Task<List<OptionsResponses>> GetBankAccountByUser(int UserId);

        Task<List<OptionsResponses>> GetBankAccountType();

        Task<List<OptionsResponses>> GetoffersRequestsPeriod();

        Task<List<OptionsResponses>> GetOfferType();
        Task<List<OptionsResponses>> GetOfferStatus();
        Task<List<OptionsResponses>> GetDocumentsType();

        Task<List<OptionsResponses>> GetEntityType();

        Task<List<OptionsResponses>> GetWarranty();

        Task<List<OptionsResponses>> GetWarrantyField(int WarrantyId);

        Task<List<OptionsResponses>> GetBadged();

        Task<OptionsResponses> GetCommission(int BadgeId);

        Task<List<OptionsResponses>> GetModality();

        Task<List<OptionsResponses>> GetPeriodData();

        Task<List<OptionsResponses>> GetAmortizationTablesData();

        Task<List<OptionsResponses>> GetRequestStatusData();

        Task<IEnumerable<RequestStatus>> GetRequestStatusByMenuData();
    }

}
