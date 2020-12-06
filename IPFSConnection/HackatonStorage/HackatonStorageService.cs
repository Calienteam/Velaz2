using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Contracts.Contracts.HackatonStorage.ContractDefinition;

namespace Contracts.Contracts.HackatonStorage
{
    public partial class HackatonStorageService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, HackatonStorageDeployment hackatonStorageDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<HackatonStorageDeployment>().SendRequestAndWaitForReceiptAsync(hackatonStorageDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, HackatonStorageDeployment hackatonStorageDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<HackatonStorageDeployment>().SendRequestAsync(hackatonStorageDeployment);
        }

        public static async Task<HackatonStorageService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, HackatonStorageDeployment hackatonStorageDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, hackatonStorageDeployment, cancellationTokenSource);
            return new HackatonStorageService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public HackatonStorageService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> EmitVideoPasswordRequestAsync(EmitVideoPasswordFunction emitVideoPasswordFunction)
        {
             return ContractHandler.SendRequestAsync(emitVideoPasswordFunction);
        }

        public Task<TransactionReceipt> EmitVideoPasswordRequestAndWaitForReceiptAsync(EmitVideoPasswordFunction emitVideoPasswordFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(emitVideoPasswordFunction, cancellationToken);
        }

        public Task<string> EmitVideoPasswordRequestAsync(string encryptedPassword, string ipfsHash, string buyerAddress)
        {
            var emitVideoPasswordFunction = new EmitVideoPasswordFunction();
                emitVideoPasswordFunction.EncryptedPassword = encryptedPassword;
                emitVideoPasswordFunction.IpfsHash = ipfsHash;
                emitVideoPasswordFunction.BuyerAddress = buyerAddress;
            
             return ContractHandler.SendRequestAsync(emitVideoPasswordFunction);
        }

        public Task<TransactionReceipt> EmitVideoPasswordRequestAndWaitForReceiptAsync(string encryptedPassword, string ipfsHash, string buyerAddress, CancellationTokenSource cancellationToken = null)
        {
            var emitVideoPasswordFunction = new EmitVideoPasswordFunction();
                emitVideoPasswordFunction.EncryptedPassword = encryptedPassword;
                emitVideoPasswordFunction.IpfsHash = ipfsHash;
                emitVideoPasswordFunction.BuyerAddress = buyerAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(emitVideoPasswordFunction, cancellationToken);
        }

        public Task<string> GetIpfsHashQueryAsync(GetIpfsHashFunction getIpfsHashFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetIpfsHashFunction, string>(getIpfsHashFunction, blockParameter);
        }

        
        public Task<string> GetIpfsHashQueryAsync(string addr, BlockParameter blockParameter = null)
        {
            var getIpfsHashFunction = new GetIpfsHashFunction();
                getIpfsHashFunction.Addr = addr;
            
            return ContractHandler.QueryAsync<GetIpfsHashFunction, string>(getIpfsHashFunction, blockParameter);
        }

        public Task<BigInteger> GetPriceQueryAsync(GetPriceFunction getPriceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPriceFunction, BigInteger>(getPriceFunction, blockParameter);
        }

        
        public Task<BigInteger> GetPriceQueryAsync(string ipfsHash, BlockParameter blockParameter = null)
        {
            var getPriceFunction = new GetPriceFunction();
                getPriceFunction.IpfsHash = ipfsHash;
            
            return ContractHandler.QueryAsync<GetPriceFunction, BigInteger>(getPriceFunction, blockParameter);
        }

        public Task<string> GetPubKeyQueryAsync(GetPubKeyFunction getPubKeyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPubKeyFunction, string>(getPubKeyFunction, blockParameter);
        }

        
        public Task<string> GetPubKeyQueryAsync(string addr, BlockParameter blockParameter = null)
        {
            var getPubKeyFunction = new GetPubKeyFunction();
                getPubKeyFunction.Addr = addr;
            
            return ContractHandler.QueryAsync<GetPubKeyFunction, string>(getPubKeyFunction, blockParameter);
        }

        public Task<string> PayRequestAsync(PayFunction payFunction)
        {
             return ContractHandler.SendRequestAsync(payFunction);
        }

        public Task<TransactionReceipt> PayRequestAndWaitForReceiptAsync(PayFunction payFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(payFunction, cancellationToken);
        }

        public Task<string> PayRequestAsync(string to, string ipfsHash, string pubKey)
        {
            var payFunction = new PayFunction();
                payFunction.To = to;
                payFunction.IpfsHash = ipfsHash;
                payFunction.PubKey = pubKey;
            
             return ContractHandler.SendRequestAsync(payFunction);
        }

        public Task<TransactionReceipt> PayRequestAndWaitForReceiptAsync(string to, string ipfsHash, string pubKey, CancellationTokenSource cancellationToken = null)
        {
            var payFunction = new PayFunction();
                payFunction.To = to;
                payFunction.IpfsHash = ipfsHash;
                payFunction.PubKey = pubKey;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(payFunction, cancellationToken);
        }

        public Task<string> SetIpfsHashRequestAsync(SetIpfsHashFunction setIpfsHashFunction)
        {
             return ContractHandler.SendRequestAsync(setIpfsHashFunction);
        }

        public Task<TransactionReceipt> SetIpfsHashRequestAndWaitForReceiptAsync(SetIpfsHashFunction setIpfsHashFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setIpfsHashFunction, cancellationToken);
        }

        public Task<string> SetIpfsHashRequestAsync(string ipfsHash)
        {
            var setIpfsHashFunction = new SetIpfsHashFunction();
                setIpfsHashFunction.IpfsHash = ipfsHash;
            
             return ContractHandler.SendRequestAsync(setIpfsHashFunction);
        }

        public Task<TransactionReceipt> SetIpfsHashRequestAndWaitForReceiptAsync(string ipfsHash, CancellationTokenSource cancellationToken = null)
        {
            var setIpfsHashFunction = new SetIpfsHashFunction();
                setIpfsHashFunction.IpfsHash = ipfsHash;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setIpfsHashFunction, cancellationToken);
        }

        public Task<string> SetPriceRequestAsync(SetPriceFunction setPriceFunction)
        {
             return ContractHandler.SendRequestAsync(setPriceFunction);
        }

        public Task<TransactionReceipt> SetPriceRequestAndWaitForReceiptAsync(SetPriceFunction setPriceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPriceFunction, cancellationToken);
        }

        public Task<string> SetPriceRequestAsync(string ipfsHash, BigInteger price)
        {
            var setPriceFunction = new SetPriceFunction();
                setPriceFunction.IpfsHash = ipfsHash;
                setPriceFunction.Price = price;
            
             return ContractHandler.SendRequestAsync(setPriceFunction);
        }

        public Task<TransactionReceipt> SetPriceRequestAndWaitForReceiptAsync(string ipfsHash, BigInteger price, CancellationTokenSource cancellationToken = null)
        {
            var setPriceFunction = new SetPriceFunction();
                setPriceFunction.IpfsHash = ipfsHash;
                setPriceFunction.Price = price;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPriceFunction, cancellationToken);
        }

        public Task<string> SetPubkeyRequestAsync(SetPubkeyFunction setPubkeyFunction)
        {
             return ContractHandler.SendRequestAsync(setPubkeyFunction);
        }

        public Task<TransactionReceipt> SetPubkeyRequestAndWaitForReceiptAsync(SetPubkeyFunction setPubkeyFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPubkeyFunction, cancellationToken);
        }

        public Task<string> SetPubkeyRequestAsync(string pubKey)
        {
            var setPubkeyFunction = new SetPubkeyFunction();
                setPubkeyFunction.PubKey = pubKey;
            
             return ContractHandler.SendRequestAsync(setPubkeyFunction);
        }

        public Task<TransactionReceipt> SetPubkeyRequestAndWaitForReceiptAsync(string pubKey, CancellationTokenSource cancellationToken = null)
        {
            var setPubkeyFunction = new SetPubkeyFunction();
                setPubkeyFunction.PubKey = pubKey;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPubkeyFunction, cancellationToken);
        }
    }
}
