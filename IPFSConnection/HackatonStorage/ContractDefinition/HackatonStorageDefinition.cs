using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Contracts.Contracts.HackatonStorage.ContractDefinition
{


    public partial class HackatonStorageDeployment : HackatonStorageDeploymentBase
    {
        public HackatonStorageDeployment() : base(BYTECODE) { }
        public HackatonStorageDeployment(string byteCode) : base(byteCode) { }
    }

    public class HackatonStorageDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50610947806100206000396000f3fe60806040526004361061007b5760003560e01c8063c479ff8b1161004e578063c479ff8b146102d9578063d0e3f734146103a7578063d8da2fa814610422578063fce9512a146104ca5761007b565b806322e01192146100805780634e3b62ec146100fd578063524f38891461017857806363a4449414610205575b600080fd5b34801561008c57600080fd5b506100fb600480360360408110156100a357600080fd5b810190602081018135600160201b8111156100bd57600080fd5b8201836020820111156100cf57600080fd5b803590602001918460018302840111600160201b831117156100f057600080fd5b9193509150356104fd565b005b34801561010957600080fd5b506100fb6004803603602081101561012057600080fd5b810190602081018135600160201b81111561013a57600080fd5b82018360208201111561014c57600080fd5b803590602001918460018302840111600160201b8311171561016d57600080fd5b50909250905061052d565b34801561018457600080fd5b506101f36004803603602081101561019b57600080fd5b810190602081018135600160201b8111156101b557600080fd5b8201836020820111156101c757600080fd5b803590602001918460018302840111600160201b831117156101e857600080fd5b50909250905061054c565b60408051918252519081900360200190f35b34801561021157600080fd5b506100fb6004803603606081101561022857600080fd5b810190602081018135600160201b81111561024257600080fd5b82018360208201111561025457600080fd5b803590602001918460018302840111600160201b8311171561027557600080fd5b919390929091602081019035600160201b81111561029257600080fd5b8201836020820111156102a457600080fd5b803590602001918460018302840111600160201b831117156102c557600080fd5b9193509150356001600160a01b031661057d565b6100fb600480360360608110156102ef57600080fd5b6001600160a01b038235169190810190604081016020820135600160201b81111561031957600080fd5b82018360208201111561032b57600080fd5b803590602001918460018302840111600160201b8311171561034c57600080fd5b919390929091602081019035600160201b81111561036957600080fd5b82018360208201111561037b57600080fd5b803590602001918460018302840111600160201b8311171561039c57600080fd5b509092509050610621565b3480156103b357600080fd5b506100fb600480360360208110156103ca57600080fd5b810190602081018135600160201b8111156103e457600080fd5b8201836020820111156103f657600080fd5b803590602001918460018302840111600160201b8311171561041757600080fd5b509092509050610748565b34801561042e57600080fd5b506104556004803603602081101561044557600080fd5b50356001600160a01b0316610762565b6040805160208082528351818301528351919283929083019185019080838360005b8381101561048f578181015183820152602001610477565b50505050905090810190601f1680156104bc5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b3480156104d657600080fd5b50610455600480360360208110156104ed57600080fd5b50356001600160a01b031661080c565b80600284846040518083838082843791909101948552505060405192839003602001909220929092555050505050565b33600090815260016020526040902061054790838361087e565b505050565b6000600283836040518083838082843791909101948552505060405192839003602001909220549250505092915050565b7f5f15a434e5d0860def36125aa4374ac92a2235b18632b85c6c41a73502ce53ab8585858585604051808060200180602001846001600160a01b031681526020018381038352888882818152602001925080828437600083820152601f01601f191690910184810383528681526020019050868680828437600083820152604051601f909101601f1916909201829003995090975050505050505050a15050505050565b6002848460405180838380828437808301925050509250505090815260200160405180910390205434101561065557600080fd5b6040516001600160a01b038616903480156108fc02916000818181858888f1935050505015801561068a573d6000803e3d6000fd5b507fde61ba1edec1bef8a200a3cf446a98fa2385c4e345c97d50b27879ec8b9742ac3386348787878760405180886001600160a01b03168152602001876001600160a01b0316815260200186815260200180602001806020018381038352878782818152602001925080828437600083820152601f01601f191690910184810383528581526020019050858580828437600083820152604051601f909101601f19169092018290039b50909950505050505050505050a15050505050565b33600090815260208190526040902061054790838361087e565b6001600160a01b03811660009081526001602081815260409283902080548451600294821615610100026000190190911693909304601f810183900483028401830190945283835260609390918301828280156108005780601f106107d557610100808354040283529160200191610800565b820191906000526020600020905b8154815290600101906020018083116107e357829003601f168201915b50505050509050919050565b6001600160a01b0381166000908152602081815260409182902080548351601f60026000196101006001861615020190931692909204918201849004840281018401909452808452606093928301828280156108005780601f106107d557610100808354040283529160200191610800565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f106108bf5782800160ff198235161785556108ec565b828001600101855582156108ec579182015b828111156108ec5782358255916020019190600101906108d1565b506108f89291506108fc565b5090565b5b808211156108f857600081556001016108fd56fea26469706673582212205f59eb511eb82915021401d30ab5798dd98043e70feb0f6689d544735b3ee2de64736f6c63430007000033";
        public HackatonStorageDeploymentBase() : base(BYTECODE) { }
        public HackatonStorageDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class EmitVideoPasswordFunction : EmitVideoPasswordFunctionBase { }

    [Function("emitVideoPassword")]
    public class EmitVideoPasswordFunctionBase : FunctionMessage
    {
        [Parameter("string", "encryptedPassword", 1)]
        public virtual string EncryptedPassword { get; set; }
        [Parameter("string", "ipfsHash", 2)]
        public virtual string IpfsHash { get; set; }
        [Parameter("address", "buyerAddress", 3)]
        public virtual string BuyerAddress { get; set; }
    }

    public partial class GetIpfsHashFunction : GetIpfsHashFunctionBase { }

    [Function("getIpfsHash", "string")]
    public class GetIpfsHashFunctionBase : FunctionMessage
    {
        [Parameter("address", "addr", 1)]
        public virtual string Addr { get; set; }
    }

    public partial class GetPriceFunction : GetPriceFunctionBase { }

    [Function("getPrice", "uint256")]
    public class GetPriceFunctionBase : FunctionMessage
    {
        [Parameter("string", "ipfsHash", 1)]
        public virtual string IpfsHash { get; set; }
    }

    public partial class GetPubKeyFunction : GetPubKeyFunctionBase { }

    [Function("getPubKey", "string")]
    public class GetPubKeyFunctionBase : FunctionMessage
    {
        [Parameter("address", "addr", 1)]
        public virtual string Addr { get; set; }
    }

    public partial class PayFunction : PayFunctionBase { }

    [Function("pay")]
    public class PayFunctionBase : FunctionMessage
    {
        [Parameter("address", "_to", 1)]
        public virtual string To { get; set; }
        [Parameter("string", "ipfsHash", 2)]
        public virtual string IpfsHash { get; set; }
        [Parameter("string", "pubKey", 3)]
        public virtual string PubKey { get; set; }
    }

    public partial class SetIpfsHashFunction : SetIpfsHashFunctionBase { }

    [Function("setIpfsHash")]
    public class SetIpfsHashFunctionBase : FunctionMessage
    {
        [Parameter("string", "ipfsHash", 1)]
        public virtual string IpfsHash { get; set; }
    }

    public partial class SetPriceFunction : SetPriceFunctionBase { }

    [Function("setPrice")]
    public class SetPriceFunctionBase : FunctionMessage
    {
        [Parameter("string", "ipfsHash", 1)]
        public virtual string IpfsHash { get; set; }
        [Parameter("uint256", "price", 2)]
        public virtual BigInteger Price { get; set; }
    }

    public partial class SetPubkeyFunction : SetPubkeyFunctionBase { }

    [Function("setPubkey")]
    public class SetPubkeyFunctionBase : FunctionMessage
    {
        [Parameter("string", "pubKey", 1)]
        public virtual string PubKey { get; set; }
    }

    public partial class PaymentEventDTO : PaymentEventDTOBase { }

    [Event("Payment")]
    public class PaymentEventDTOBase : IEventDTO
    {
        [Parameter("address", "_from", 1, false )]
        public virtual string From { get; set; }
        [Parameter("address", "_to", 2, false )]
        public virtual string To { get; set; }
        [Parameter("uint256", "amount", 3, false )]
        public virtual BigInteger Amount { get; set; }
        [Parameter("string", "ipfsHash", 4, false )]
        public virtual string IpfsHash { get; set; }
        [Parameter("string", "pubKey", 5, false )]
        public virtual string PubKey { get; set; }
    }

    public partial class VideoPasswordEventDTO : VideoPasswordEventDTOBase { }

    [Event("VideoPassword")]
    public class VideoPasswordEventDTOBase : IEventDTO
    {
        [Parameter("string", "encryptedPassword", 1, false )]
        public virtual string EncryptedPassword { get; set; }
        [Parameter("string", "ipfsHash", 2, false )]
        public virtual string IpfsHash { get; set; }
        [Parameter("address", "buyerAddress", 3, false )]
        public virtual string BuyerAddress { get; set; }
    }



    public partial class GetIpfsHashOutputDTO : GetIpfsHashOutputDTOBase { }

    [FunctionOutput]
    public class GetIpfsHashOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetPriceOutputDTO : GetPriceOutputDTOBase { }

    [FunctionOutput]
    public class GetPriceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetPubKeyOutputDTO : GetPubKeyOutputDTOBase { }

    [FunctionOutput]
    public class GetPubKeyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }








}
