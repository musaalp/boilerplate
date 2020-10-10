using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace App.Infrustructure.RabbitMQ
{
    public class ChannelFactory : IChannelFactory
    {
        private readonly IConnectionFactory _connectionFactory;
        private IConnection _connection;
        private readonly ILogger<ChannelFactory> _logger;
        private readonly RabbitMQConfiguration _rabbitMQConfiguration;
        private readonly ConcurrentBag<IModel> _channels;

        public ChannelFactory(IConnectionFactory connectionFactory, ILogger<ChannelFactory> logger, IOptions<RabbitMQConfiguration> options)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
            _rabbitMQConfiguration = options.Value;
            _channels = new ConcurrentBag<IModel>();
        }

        public async Task<IModel> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var connection = await GetConnectionAsync(cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();

            var channel = connection.CreateModel();

            _channels.Add(channel);

            return channel;
        }

        public virtual Task ConnectAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                _logger.LogInformation($"Creating a new connection for {_rabbitMQConfiguration.Hostnames.Count} hosts");

                _connection = _connectionFactory.CreateConnection(_rabbitMQConfiguration.Hostnames, _rabbitMQConfiguration.ClientProvidedName);
                _connection.ConnectionShutdown += (sender, args) =>
                {
                    _logger.LogWarning($"Connection was shutdow by {args.Initiator}. ReplyText {args.ReplyText}");
                };
            }
            catch (BrokerUnreachableException e)
            {
                _logger.LogInformation("Unable to connect to broker.", e);
                throw;
            }

            return Task.CompletedTask;
        }

        private async Task<IConnection> GetConnectionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (_connection == null)
            {
                await ConnectAsync();
            }

            if (_connection.IsOpen)
            {
                _logger.LogDebug("Existing connection is open and will be used");

                return _connection;
            }

            _logger.LogInformation("The existing connection is not open");

            if (_connection.CloseReason != null && _connection.CloseReason.Initiator == ShutdownInitiator.Application)
            {
                _logger.LogInformation("Connection is closed with Application as initiator. It will not be recovered.");
                _connection.Dispose();

                throw new Exception("Closed connection initiated by the Application. A new connection will not be created, and no channel can be created");
            }

            if (!(_connection is IRecoverable recoverable))
            {
                _logger.LogInformation("Connection is not recoverable");
                _connection.Dispose();
                throw new Exception("The non recoverable connection is closed. A channel can not be created.");
            }

            _logger.LogDebug("Connection is recoverable. Waiting for 'Recover' event to be triggered.");

            var recoverTcs = new TaskCompletionSource<IConnection>();

            cancellationToken.Register(() => recoverTcs.TrySetCanceled());

            EventHandler<EventArgs> completeTask = null;
            completeTask = (sender, args) =>
            {
                if (recoverTcs.Task.IsCanceled)
                {
                    return;
                }
                _logger.LogInformation("Connection has been recovered!");
                recoverTcs.TrySetResult(recoverable as IConnection);
                recoverable.Recovery -= completeTask;
            };

            recoverable.Recovery += completeTask;
            return await recoverTcs.Task;
        }

        public void Dispose()
        {
            foreach (var channel in _channels)
            {
                channel?.Dispose();
            }
            _connection?.Dispose();
        }
    }
}
