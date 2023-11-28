using Simplyfund.Bll.Services.BaseServices;
using Simplyfund.Bll.ServicesInterface.Customers;
using Simplyfund.Dal.Data.IBaseDatas.Auth;
using Simplyfund.Dal.DataInterface.IBaseDatas;
using SimplyFund.Domain.Dto.Login;
using SimplyFund.Domain.Models.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.Services.Customers
{
    public class ServiceCustomer : BaseService<Customer>, IServiceCustomer
    {
        IBaseDatas<Customer> baseModel;
        IDataAuth dataAuth;
        public ServiceCustomer(IBaseDatas<Customer> baseModel, IDataAuth dataAuth) : base(baseModel)
        {
            this.baseModel = baseModel;
            this.dataAuth = dataAuth;
        }


        public override async Task<Customer> AddAndReturnAsync(Customer entity)
        {
            try
            {
                await Validation(entity);

                var add = await baseModel.AddAndReturnAsync(entity);

                if (add != null)
                {
                    var user = new User()
                    {
                        Password = "",
                        Rol = "Customer",
                        Email = add.Email,
                        UserName = add.Email,
                        UserId = add.Id,

                    };

                   string userAcoount = await dataAuth.CreateUser(user);
                    add.Password = userAcoount;
                    return add;
                }
                else
                {
                    throw new Exception("Error agregando");
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task Validation(Customer entity)
        {
            if (entity != null)
            {
                var email = await baseModel.GetAsync(x => x.Email == entity.Email);
                if (email != null)
                {
                    throw new Exception("Ya tenemos una cuenta registrada con este correo electronico.");
                }
            }
            else
            {
                throw new Exception("No puede ser null en modelo1");
            }
        }
    }
}
