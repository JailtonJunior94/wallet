using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Transaction.Domain.Interfaces;

namespace Transaction.Worker
{
    public class Worker : BackgroundService
    {
        private readonly IReceiverMessageHandle _handle;

        public Worker(IReceiverMessageHandle handle)
        {
            _handle = handle;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _handle.RegisterOnMessageHandlerAndReceiveMessages();
        }
    }
}
