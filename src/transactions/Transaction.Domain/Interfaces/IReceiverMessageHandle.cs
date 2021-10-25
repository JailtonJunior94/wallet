using System.Threading.Tasks;

namespace Transaction.Domain.Interfaces
{
    public interface IReceiverMessageHandle
    {
        Task RegisterOnMessageHandlerAndReceiveMessages();
        Task CloseQueueAsync();
        ValueTask DisposeAsync();
    }
}
