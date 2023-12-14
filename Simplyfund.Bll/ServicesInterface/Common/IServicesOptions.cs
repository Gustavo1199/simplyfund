using SimplyFund.Domain.Dto.Common;
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


    }
}
