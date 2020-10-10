using App.Application.Bus;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrustructure.RabbitMQ.Extensions
{
    public static class RabbitMQExtensions
    {
        public static void UseRabbitMQ(this IApplicationBuilder app)
        {
            app.ApplicationServices.GetService<IBusMessageSubscriber>().SubscribeAsync();
        }
    }
}
