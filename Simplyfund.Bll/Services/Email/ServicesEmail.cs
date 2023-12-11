using Newtonsoft.Json;
using Simplyfund.Bll.ServicesInterface.Email;
using Simplyfund.Dal.DataInterface.Email;
using SimplyFund.Domain.Dto.Email;
using SimplyFund.Domain.Models.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Bll.Services.Email
{
    public class ServicesEmail : IServicesEmail
    {
        IDataEmail dataEmail;
        public ServicesEmail(IDataEmail dataEmail)
        {
            this.dataEmail = dataEmail;
        }

        public async Task<string> SendMail(string json) {
            try
            {
                var entity = JsonConvert.DeserializeObject<RequestEmail>(json);

                 await dataEmail.SendMail(entity);
                return "true";
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
