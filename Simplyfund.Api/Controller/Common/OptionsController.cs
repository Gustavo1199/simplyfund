using Microsoft.AspNetCore.Mvc;
using Simplyfund.Bll.ServicesInterface.Common;
using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Dto.Responses;
using SimplyFund.Domain.Models.Requests;

namespace Simplyfund.Api.Controller.Common
{
    [ApiController]
    [Route("api/Common/[Controller]")]
    public class OptionsController : ControllerBase
    {
        IServicesOptions servicesOptions;
        ErrorResponses errorResponses;

        public OptionsController(IServicesOptions servicesOptions)
        {
            this.servicesOptions = servicesOptions;
            errorResponses = new ErrorResponses();
        }

        [HttpGet("GetCountry", Name = "GetCountry")]
        public async Task<ActionResult<List<OptionsResponses>>> GetCountry()
        {
            try
            {
                return await servicesOptions.GetCountry();

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        [HttpGet("GetProvince", Name = "GetProvince")]
        public async Task<ActionResult<List<OptionsResponses>>> GetProvince()
        {
            try
            {
                return await servicesOptions.GetProvince();

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        [HttpGet("GetCustomerTypes", Name = "GetCustomerTypes")]
        public async Task<ActionResult<List<OptionsResponses>>> GetCustomerTypes()
        {
            try
            {
                return await servicesOptions.GetCustomerTypes();

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        [HttpGet("GetCategories")]
        public async Task<ActionResult<List<OptionsResponses>>> GetCategories()
        {
            try
            {
                return await servicesOptions.GetCategories();

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }


        [HttpGet("GetIdentityTypeData", Name = "GetIdentityTypeData")]
        public async Task<ActionResult<List<OptionsResponses>>> GetIdentityTypeData()
        {
            try
            {
                return await servicesOptions.GetIdentityTypeData();

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        [HttpGet("GetBankAccountType", Name = "GetBankAccountType")]

        public async Task<ActionResult<List<OptionsResponses>>> GetBankAccountType()
        {
            try
            {
                return await servicesOptions.GetBankAccountType();

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        [HttpGet("GetoffersRequestsPeriod", Name = "GetoffersRequestsPeriod")]

        public async Task<ActionResult<List<OptionsResponses>>> GetoffersRequestsPeriod()
        {
            try
            {
                return await servicesOptions.GetoffersRequestsPeriod();

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }


        [HttpGet("GetOfferType", Name = "GetOfferType")]

        public async Task<ActionResult<List<OptionsResponses>>> GetOfferType()
        {
            try
            {
                return await servicesOptions.GetOfferType();

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        [HttpGet("GetOfferStatus", Name = "GetOfferStatus")]

        public async Task<ActionResult<List<OptionsResponses>>> GetOfferStatus()
        {
            try
            {
                return await servicesOptions.GetOfferStatus();

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }

        [HttpGet("GetBankAccountByUser/{id}", Name = "GetBankAccountByUser")]
        public async Task<ActionResult<List<OptionsResponses>>> GetBankAccountByUser(int id)
        {
            try
            {
                return await servicesOptions.GetBankAccountByUser(id);

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }


        [HttpGet("GetDocumentsType", Name = "GetDocumentsType")]
        public async Task<ActionResult<List<OptionsResponses>>> GetDocumentsType()
        {
            try
            {
                return await servicesOptions.GetDocumentsType();

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }



        [HttpGet("GetEntityType", Name = "GetEntityType")]
        public async Task<ActionResult<List<OptionsResponses>>> GetEntityType()
        {
            try
            {
                return Ok(await servicesOptions.GetEntityType());

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }


        [HttpGet("GetFieldsByWarranty/{WarrantyId:int}", Name = "GetFieldsByWarranty")]
        public async Task<ActionResult<List<OptionsResponses>>> GetWarrantyField(int WarrantyId)
        {
            try
            {
                return Ok(await servicesOptions.GetWarrantyField(WarrantyId));

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }


        [HttpGet("GetBadged", Name = "GetBadged")]
        public async Task<ActionResult<List<OptionsResponses>>> GetBadged()
        {
            try
            {
                return Ok(await servicesOptions.GetBadged());

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }


        [HttpGet("GetWarranty", Name = "GetWarranty")]
        public async Task<ActionResult<List<OptionsResponses>>> GetWarranty()
        {
            try
            {
                return Ok(await servicesOptions.GetWarranty());

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }


        [HttpGet("GetCommission/{BadgeId:int}", Name = "GetCommission")]
        public async Task<ActionResult<OptionsResponses>> GetCommission(int BadgeId)
        {
            try
            {
                return Ok(await servicesOptions.GetCommission(BadgeId));

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }


        [HttpGet("GetModality", Name = "GetModality")]
        public async Task<ActionResult<List<OptionsResponses>>> GetModality()
        {
            try
            {
                return Ok(await servicesOptions.GetModality());

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }  
        
        [HttpGet("GetPeriodData", Name = "GetPeriodData")]
        public async Task<ActionResult<List<OptionsResponses>>> GetPeriodData()
        {
            try
            {
                return Ok(await servicesOptions.GetPeriodData());

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }
      

        [HttpGet("GetAmortizationTables", Name = "GetAmortizationTables")]
        public async Task<ActionResult<List<OptionsResponses>>> GetAmortizationTablesData()
        {
            try
            {
                return Ok(await servicesOptions.GetAmortizationTablesData());

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }


        [HttpGet("GetRequestStatus", Name = "GetRequestStatus")]
        public async Task<ActionResult<List<OptionsResponses>>> GetRequestStatusData()
        {
            try
            {
                return Ok(await servicesOptions.GetRequestStatusData());

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }
        
        
        [HttpGet("GetRequestStatusByMenuData", Name = "GetRequestStatusByMenuData")]
        public async Task<ActionResult<List<RequestStatus>>> GetRequestStatusByMenuData()
        {
            try
            {
                return Ok(await servicesOptions.GetRequestStatusByMenuData());

            }
            catch (Exception ex)
            {
                if (ex.Message == null)
                {
                    if (ex.InnerException != null)
                    {
                        errorResponses.Message = ex.InnerException.Message;
                    }
                }
                else
                {
                    errorResponses.Message = ex.Message;
                }
                return StatusCode(500, errorResponses);
            }
        }
    }


}
