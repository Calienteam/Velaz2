using System.Threading.Tasks;
using Nethereum.JsonRpc.Client.RpcMessages;

namespace Hackathon_VideoSharing_Platform.Client
{
    public interface IMetamaskInterop
    {
        ValueTask<bool> EnableEthereumAsync();
        ValueTask<bool> CheckMetamaskAvailability();
        ValueTask<string> GetSelectedAddress();
        ValueTask<RpcResponseMessage> SendAsync(RpcRequestMessage rpcRequestMessage);
        ValueTask<RpcResponseMessage> SendTransactionAsync(MetamaskRpcRequestMessage rpcRequestMessage);
    }

}
