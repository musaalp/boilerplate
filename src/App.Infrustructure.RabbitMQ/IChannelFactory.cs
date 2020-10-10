using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Infrustructure.RabbitMQ
{
    public interface IChannelFactory : IDisposable
    {
        Task<IModel> CreateAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
