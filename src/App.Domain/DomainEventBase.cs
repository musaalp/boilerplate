using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain
{
    public class DomainEventBase : IDomainEvent
    {
        public Guid Id { get; protected set; }
        public DateTime OccurredOn { get; protected set; }
    }
}
