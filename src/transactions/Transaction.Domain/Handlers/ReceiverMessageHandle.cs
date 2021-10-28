using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;
using Transaction.Domain.Interfaces;

namespace Transaction.Domain.Handlers
{
    public class ReceiverMessageHandle : IReceiverMessageHandle
    {
        private readonly ILogger _logger;
        private ServiceBusProcessor _processor;
        private readonly ServiceBusClient _client;
        private const string QUEUE_NAME = "";

        public ReceiverMessageHandle(ILogger<ReceiverMessageHandle> logger)
        {
            _logger = logger;
            _client = new ServiceBusClient("");
        }

        public async Task RegisterOnMessageHandlerAndReceiveMessages()
        {
            ServiceBusProcessorOptions serviceBusProcessorOptions = new()
            {
                MaxConcurrentCalls = Environment.ProcessorCount,
                AutoCompleteMessages = false,
            };

            _processor = _client.CreateProcessor(QUEUE_NAME, serviceBusProcessorOptions);
            _processor.ProcessMessageAsync += ProcessMessagesAsync;
            _processor.ProcessErrorAsync += ProcessErrorAsync;

            await _processor.StartProcessingAsync();
        }

        private async Task ProcessMessagesAsync(ProcessMessageEventArgs args)
        {
            var message = Encoding.UTF8.GetString(args.Message.Body);
            _logger.LogInformation($"[{nameof(ReceiverMessageHandle)}] [{nameof(ProcessMessagesAsync)}] [{message}]");

            await args.CompleteMessageAsync(args.Message);
        }

        private Task ProcessErrorAsync(ProcessErrorEventArgs arg)
        {
            _logger.LogError(arg.Exception, "Message handler encountered an exception");
            _logger.LogDebug($"[{nameof(ReceiverMessageHandle)}] [{nameof(ProcessErrorAsync)}] [{arg.ErrorSource}]");
            _logger.LogDebug($"[{nameof(ReceiverMessageHandle)}] [{nameof(ProcessErrorAsync)}] [{arg.EntityPath}]");
            _logger.LogDebug($"[{nameof(ReceiverMessageHandle)}] [{nameof(ProcessErrorAsync)}] [{arg.FullyQualifiedNamespace}]");

            return Task.CompletedTask;
        }

        public async ValueTask DisposeAsync()
        {
            if (_processor != null)
                await _processor.DisposeAsync();

            if (_client != null)
                await _client.DisposeAsync();
        }

        public async Task CloseQueueAsync()
        {
            await _processor.CloseAsync();
        }
    }
}
