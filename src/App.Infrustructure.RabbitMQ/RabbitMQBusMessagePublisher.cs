using App.Application.Bus;
using App.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrustructure.RabbitMQ
{
    public class RabbitMQBusMessagePublisher : IBusMessagePublisher
    {
        public Task PublishAsync<TMessage>(TMessage message) where TMessage : IDomainEvent
        {
            throw new NotImplementedException();
        }
    }
}
