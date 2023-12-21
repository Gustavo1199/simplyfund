using Simplyfund.Bll.ServicesInterface.Common;
using Simplyfund.Dal.DataInterface.IBaseDatas;
using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Models.Common;
using SimplyFund.Domain.Models.Customer;
using SimplyFund.Domain.Models.Requests;
using SimplyFund.Domain.Models.Requests.Offers;
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
        IBaseDatas<RequestCategory> RequestCategoryData;
        IBaseDatas<BankAccount> BankAccountData;
        IBaseDatas<BankAccountType> BankAccountTypeData;
        IBaseDatas<OfferRequestPeriod> offersRequestsPeriodData;
        IBaseDatas<OfferType> OfferTypeData;
        IBaseDatas<OfferStatus> OfferStatusData;

        public ServicesOptions(IBaseDatas<Country> countryData, IBaseDatas<Province> proviceData, IBaseDatas<CustomerType> customerTypeseData, IBaseDatas<IdentityType> identityTypeData, IBaseDatas<RequestCategory> requestCategoryData, IBaseDatas<BankAccount> bankAccountData, IBaseDatas<BankAccountType> bankAccountTypeData, IBaseDatas<OfferRequestPeriod> offersRequestsPeriodData, IBaseDatas<OfferType> offerTypeData, IBaseDatas<OfferStatus> offerStatusData)
        {
            this.countryData = countryData;
            this.proviceData = proviceData;
            CustomerTypeData = customerTypeseData;
            IdentityTypeData = identityTypeData;
            RequestCategoryData = requestCategoryData;
            BankAccountData = bankAccountData;
            BankAccountTypeData = bankAccountTypeData;
            this.offersRequestsPeriodData = offersRequestsPeriodData;
            OfferTypeData = offerTypeData;
            OfferStatusData = offerStatusData;
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

        public async Task<List<OptionsResponses>> GetCategories()
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await RequestCategoryData.GetAsync();

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
        
        public async Task<List<OptionsResponses>> GetBankAccountType()
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await BankAccountTypeData.GetAsync();

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
        
        public async Task<List<OptionsResponses>> GetoffersRequestsPeriod()
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await offersRequestsPeriodData.GetAsync();

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        optionsResponses.Add(new OptionsResponses()
                        {
                            displayname = item.Description,
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
        
        public async Task<List<OptionsResponses>> GetOfferType()
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await OfferTypeData.GetAsync();

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        optionsResponses.Add(new OptionsResponses()
                        {
                            displayname = item.Description,
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
        
        
        public async Task<List<OptionsResponses>> GetOfferStatus()
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await OfferStatusData.GetAsync();

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        optionsResponses.Add(new OptionsResponses()
                        {
                            displayname = item.Description,
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


        public async Task<List<OptionsResponses>> GetBankAccountByUser(int UserId)
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await BankAccountData.GetManyAsync(x=>x.CustomerId == UserId);

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        if (item.Bank != null)
                        {
                            optionsResponses.Add(new OptionsResponses()
                            {
                                displayname = $"{item.Bank.Name} - {item.AccountNumber}" ,
                                value = item.Id
                            });
                        }
                        
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
