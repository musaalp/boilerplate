using App.Application.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrustructure.RabbitMQ
{
    public class RabbitMQBusMessageSubscriber : IBusMessageSubscriber
    {
        public Task SubscribeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
