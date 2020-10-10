using App.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Bus
{
    public interface IBusMessagePublisher
    {
        Task PublishAsync<TMessage>(TMessage message) where TMessage : IDomainEvent;
    }
}
