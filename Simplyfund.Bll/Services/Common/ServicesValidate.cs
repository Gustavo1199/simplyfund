using Simplyfund.Bll.ServicesInterface.Common;
using Simplyfund.Dal.DataInterface.IBaseDatas;
using SimplyFund.Domain.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.Services.Common
{
    public class ServicesValidate : IServicesValidate
    {
        IBaseDatas<Customer> dataCustomer;
        public ServicesValidate(IBaseDatas<Customer> dataCustomer)
        {
            this.dataCustomer = dataCustomer;
        }

        public async Task<bool> ValidateidentityNumber(string identityValue)
        {
            try
            {
                var identity = await dataCustomer.GetAsync(x => x.IdentityNumber == identityValue);
                if (identity != null)
                {
                    throw new ArgumentException("Ya existe este documento registrado.");
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> ValidateEmail(string emailValue)
        {
            try
            {
                var email = await dataCustomer.GetAsync(x => x.Email == emailValue);
                if (email != null)
                {
                    throw new ArgumentException("Ya existe este correo registrado.");
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    


    }

}
