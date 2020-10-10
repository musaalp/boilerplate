using App.Application.Bus;
using App.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrustructure.RabbitMQ
{
    public class RabbitMQBusMessageProcessor : IBusMessageProcessor
    {
        public Task Process<T>(T @event) where T : DomainEventBase
        {
            throw new NotImplementedException();
        }
    }
}
