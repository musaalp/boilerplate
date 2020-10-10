using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain
{
    public interface IDomainEvent : INotification
    {
    }
}
