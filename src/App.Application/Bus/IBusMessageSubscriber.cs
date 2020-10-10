using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Bus
{
    public interface IBusMessageSubscriber
    {
        Task SubscribeAsync();
    }
}
