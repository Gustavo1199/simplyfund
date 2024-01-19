using Simplyfund.Bll.ServicesInterface.Common;
using Simplyfund.Dal.DataInterface.IBaseDatas;
using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Models.Common;
using SimplyFund.Domain.Models.Customer;
using SimplyFund.Domain.Models.Requests;
using SimplyFund.Domain.Models.Requests.Offers;
using SimplyFund.Domain.Models.Warrantys;
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
        IBaseDatas<Document> DocumentData;
        IBaseDatas<EntityType> EntityTypeData;
        IBaseDatas<Warranty> WarrantyData;
        IBaseDatas<WarrantyField> WarrantyFieldData;
        IBaseDatas<Badge> BadgedData;
        IBaseDatas<Commission> CommissionData;
        IBaseDatas<Modality> ModalityData;
        IBaseDatas<Period> PeriodData;
        IBaseDatas<AmortizationTable> AmortizationTablesData;
        IBaseDatas<RequestStatus> RequestStatusData;

        public ServicesOptions(IBaseDatas<Country> countryData, IBaseDatas<Province> proviceData, IBaseDatas<CustomerType> customerTypeseData, IBaseDatas<IdentityType> identityTypeData, IBaseDatas<RequestCategory> requestCategoryData, IBaseDatas<BankAccount> bankAccountData, IBaseDatas<BankAccountType> bankAccountTypeData, IBaseDatas<OfferRequestPeriod> offersRequestsPeriodData, IBaseDatas<OfferType> offerTypeData, IBaseDatas<OfferStatus> offerStatusData, IBaseDatas<Document> documentData, IBaseDatas<EntityType> entityTypeData, IBaseDatas<Warranty> warrantyData, IBaseDatas<WarrantyField> warrantyFieldData, IBaseDatas<Badge> badgedData, IBaseDatas<Commission> commissionData, IBaseDatas<Modality> modalityData, IBaseDatas<Period> periodData, IBaseDatas<AmortizationTable> amortizationTablesData, IBaseDatas<RequestStatus> requestStatusData)
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
            DocumentData = documentData;
            EntityTypeData = entityTypeData;
            WarrantyData = warrantyData;
            WarrantyFieldData = warrantyFieldData;
            BadgedData = badgedData;
            CommissionData = commissionData;
            ModalityData = modalityData;
            PeriodData = periodData;
            AmortizationTablesData = amortizationTablesData;
            RequestStatusData = requestStatusData;
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

        public async Task<List<OptionsResponses>> GetDocumentsType()
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await DocumentData.GetAsync();

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

        public async Task<List<OptionsResponses>> GetEntityType()
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await EntityTypeData.GetAsync();

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
        
        public async Task<List<OptionsResponses>> GetWarranty()
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await WarrantyData.GetAsync();

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        optionsResponses.Add(new OptionsResponses()
                        {
                            displayname = item.Name,
                            description = item.Document,
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

        public async Task<List<OptionsResponses>> GetWarrantyField(int WarrantyId)
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await WarrantyFieldData.GetManyAsync(x => x.WarrantyId == WarrantyId);

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        optionsResponses.Add(new OptionsResponses()
                        {
                            displayname = item.Field,
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
        public async Task<List<OptionsResponses>> GetBadged()
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await BadgedData.GetAsync();

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        optionsResponses.Add(new OptionsResponses()
                        {
                            displayname = item.Iso4217,
                            description = item.Currency,
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
        
        public async Task<OptionsResponses> GetCommission(int BadgeId)
        {
            try
            {
                OptionsResponses optionsResponses = new OptionsResponses();
                var data = await CommissionData.GetAsync(x=>x.BadgeId == BadgeId);

                if (data != null)
                {
                    optionsResponses.displayname = data.AnnualPercentage.ToString();
                    optionsResponses.value = data.Id;
                                     
                }

                return optionsResponses;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<OptionsResponses>> GetModality()
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await ModalityData.GetAsync();

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
        public async Task<List<OptionsResponses>> GetPeriodData()
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await PeriodData.GetAsync();

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
        
        public async Task<List<OptionsResponses>> GetAmortizationTablesData()
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await AmortizationTablesData.GetAsync();

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
        
        public async Task<IEnumerable<RequestStatus>> GetRequestStatusByMenuData()
        {
            try
            {
                
                var data = await RequestStatusData.GetAsync();

                return data;

               

            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<List<OptionsResponses>> GetRequestStatusData()
        {
            try
            {
                List<OptionsResponses> optionsResponses = new List<OptionsResponses>();
                var data = await RequestStatusData.GetAsync();

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








    }


}
