using EasyNetQ.Internals;
using Simplyfund.Bll.Services.BaseServices;
using Simplyfund.Bll.ServicesInterface.Customers;
using Simplyfund.Dal.Data.IBaseDatas.Auth;
using Simplyfund.Dal.DataInterface.IBaseDatas;
using Simplyfund.Dal.Rabbit;
using SimplyFund.Domain.Dto.Common;
using SimplyFund.Domain.Dto.Email;
using SimplyFund.Domain.Dto.Login;
using SimplyFund.Domain.Models.Client;
using SimplyFund.Domain.Models.Common;
using SimplyFund.Domain.Models.Customer;
using SimplyFund.Domain.Models.RabbitMQ;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using File = SimplyFund.Domain.Models.Common.File;

namespace Simplyfund.Bll.Services.Customers
{
    public class ServiceCustomer : BaseService<SimplyFund.Domain.Models.Client.Customer>, IServiceCustomer
    {
        IBaseDatas<SimplyFund.Domain.Models.Client.Customer> baseModel;
        IBaseDatas<CustomerWorkingInfo> dataCustomerWorkingInfo;
        IBaseDatas<EntityType> dataEntityType;
        IBaseDatas<File> dataFile;
        IDataAuth dataAuth;
        IRabitMQProducer rabitMQProducer;
        public ServiceCustomer(IBaseDatas<SimplyFund.Domain.Models.Client.Customer> baseModel, IDataAuth dataAuth, IRabitMQProducer rabitMQProducer, IBaseDatas<CustomerWorkingInfo> dataCustomerWorkingInfo, IBaseDatas<EntityType> dataEntityType, IBaseDatas<File> dataFile) : base(baseModel)
        {
            this.baseModel = baseModel;
            this.dataAuth = dataAuth;
            this.rabitMQProducer = rabitMQProducer;
            this.dataCustomerWorkingInfo = dataCustomerWorkingInfo;
            this.dataEntityType = dataEntityType;
            this.dataFile = dataFile;
        }


        public override async Task<SimplyFund.Domain.Models.Client.Customer> AddAndReturnAsync(SimplyFund.Domain.Models.Client.Customer entity)
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
                    SendMail(add);
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


        public void SendMail(Customer add)
        {
            RequestEmail requestEmail = new RequestEmail()
            {
                Action = "Contrasena Temporal",
            Module = "Clientes",
        };
           

            requestEmail.Recipients = new List<string>() { add.Email };

            requestEmail.Entity = new Dictionary<string, string>
                        {
                            {"cliente.nombre",add.FirstName},
                            {"cliente.apellido", add.FirstLastName},
                            {"cliente.passwordTemp", add.Password},
                        };

            var request = new RequestRabbitMQ()
            {
                queue = "emailQueue",
                exchange = "emailExchange",
                message = requestEmail,
                routingkey = "email.routing.key"
            };

            rabitMQProducer.SendProductMessage(request);

        }

        private async Task Validation(SimplyFund.Domain.Models.Client.Customer entity)
        {
            if (entity != null)
            {
                var email = await baseModel.GetAsync(x => x.Email == entity.Email);
                if (email != null)
                {
                    throw new Exception("Ya tenemos una cuenta registrada con este correo electronico.");
                }


                var  rnc = await baseModel.GetAsync(x=>x.IdentityNumber == entity.IdentityNumber);
                
                if (rnc != null)
                {
                    throw new Exception("Ya tenemos un cliente registrado con este numero de documento.");
                }

            }
            else
            {
                throw new Exception("No puede ser null en modelo1");
            }
        }


        public async override Task<Customer> GetByIdAsync(int id)
        {
            try
            {
                var customer = await baseModel.GetByIdAsync(id);

                if (customer != null)
                {
                    var entityType = await dataEntityType.GetAsync(x => x.Name == EntityTypesEnum.Customer);
                    if (entityType != null)
                    {
                        var file = await dataFile.GetManyAsync(x => x.EntityId == customer.Id && x.EntityTypeId == entityType.Id);
                        if (file != null)
                        {
                            customer.Files = file.ToList();
                        }
                    }

                    var entityTypeshareholder = await dataEntityType.GetAsync(x => x.Name == EntityTypesEnum.Shareholder);


                    if (entityTypeshareholder != null)
                    {
                        if (customer.Shareholders != null)
                        {
                            List<Shareholder> shareholders = new List<Shareholder>();
                            foreach (var item in customer.Shareholders)
                            {
                                var file = await dataFile.GetManyAsync(x => x.EntityId == item.Id && x.EntityTypeId == entityTypeshareholder.Id);
                                if (file != null)
                                {
                                    item.File = file.ToList();
                                }
                                shareholders.Add(item);
                            }

                            customer.Shareholders = shareholders;
                        }
                    }

                    return customer;

                }
            
                else
                {
                    throw new Exception("Cliente no existe");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
