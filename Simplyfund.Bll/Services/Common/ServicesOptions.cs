using Simplyfund.Bll.ServicesInterface.Common;
using Simplyfund.Dal.Data.IBaseDatas;
using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Models.Common;
using SimplyFund.Domain.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.Services.Common
{
    public class ServicesOptions : IServicesOptions
    {
        IBaseDatas<Country> countryData;
        IBaseDatas<Province> proviceData;
        IBaseDatas<CustomerType> CustomerTypeData;
        IBaseDatas<IdentityType> IdentityTypeData;
        public ServicesOptions(IBaseDatas<Country> countryData, IBaseDatas<Province> proviceData, IBaseDatas<CustomerType> customerTypeseData, IBaseDatas<IdentityType> identityTypeData)
        {
            this.countryData = countryData;
            this.proviceData = proviceData;
            CustomerTypeData = customerTypeseData;
            IdentityTypeData = identityTypeData;
        }

        public async Task<List<OptionsResponses>> GetCountry()
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await countryData.GetAsync();

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        optionsResponses.Add(new OptionsResponses()
                        {
                            displayname = item.Name,
                            value = item.Id
                        });
                    }
                }

                return optionsResponses;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<List<OptionsResponses>> GetProvince()
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await proviceData.GetAsync();

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        optionsResponses.Add(new OptionsResponses()
                        {
                            displayname = item.Name,
                            value = item.Id
                        });
                    }
                }

                return optionsResponses;

            }
            catch (Exception)
            {

                throw;
            }
        } 
        
        public async Task<List<OptionsResponses>> GetCustomerTypes()
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await CustomerTypeData.GetAsync();

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        optionsResponses.Add(new OptionsResponses()
                        {
                            displayname = item.CustomerTypeName,
                            value = item.Id
                        });
                    }
                }

                return optionsResponses;

            }
            catch (Exception)
            {

                throw;
            }
        } 
        
        public async Task<List<OptionsResponses>> GetIdentityTypeData()
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await IdentityTypeData.GetAsync();

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        optionsResponses.Add(new OptionsResponses()
                        {
                            displayname = item.IdentityName,
                            value = item.Id
                        });
                    }
                }

                return optionsResponses;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}
