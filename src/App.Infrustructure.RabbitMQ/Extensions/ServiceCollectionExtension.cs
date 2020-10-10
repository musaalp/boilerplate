using App.Application.Bus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Infrustructure.RabbitMQ.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddTransient<IBusMessagePublisher, RabbitMQBusMessagePublisher>()
                .AddTransient<IBusMessageSubscriber, RabbitMQBusMessageSubscriber>()
                .AddTransient<IBusMessageProcessor, RabbitMQBusMessageProcessor>()
                .AddSingleton<IChannelFactory, ChannelFactory>()
                .AddSingleton<IConnectionFactory, ConnectionFactory>(provider =>
                {
                    var config = provider.GetService<IOptions<RabbitMQConfiguration>>().Value;

                    return new ConnectionFactory
                    {
                        VirtualHost = config.VirtualHost,
                        UserName = config.Username,
                        Password = config.Password,
                        Port = config.Port,
                        HostName = config.Hostnames.FirstOrDefault() ?? string.Empty,
                        AutomaticRecoveryEnabled = config.AutomaticRecovery,
                        TopologyRecoveryEnabled = config.TopologyRecovery,
                        NetworkRecoveryInterval = config.RecoveryInterval,
                        Ssl = config.Ssl
                    };
                });
        }
    }
}
