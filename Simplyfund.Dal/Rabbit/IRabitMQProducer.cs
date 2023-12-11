using SimplyFund.Domain.Models.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Dal.Rabbit
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage(RequestRabbitMQ requestRabbitMQ);
    }
}
