using App.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Bus
{
    public interface IBusMessageProcessor
    {
        Task Process<T>(T @event) where T : DomainEventBase;
    }
}
