using Neo;
using Neo.IO;
using Neo.Network.RPC;
using Neo.SmartContract;
using Neo.VM;
using Neo.VM.Types;
using Neo.Wallets;

namespace iDent.API.SmartContracts
{
    public class NeoContract
    {
        private readonly RpcClient rpcClient;
        private readonly KeyPair keyPair;
        private readonly UInt160 contractHash;

        public NeoContract(string rpcEndpoint, string privateKey, string contractAddress)
        {
            rpcClient = new RpcClient(new Uri(rpcEndpoint));
            keyPair = new KeyPair(privateKey.HexToBytes());
            contractHash = UInt160.Parse(contractAddress);
        }

        public void SaveData(string key, string value)
        {
            var scriptHash = new UInt160(key.ToScriptHash());
            var operation = new ContractOperation
            {
                ScriptHash = contractHash,
                Operation = "put",
                Arguments = new[] { scriptHash.ToArray(), value }
            };

            var tx = rpcClient(keyPair, operation) ?? throw new Exception("Transaction failed");
        }

        public string RetrieveData(string key)
        {
            var scriptHash = new UInt160(key.ToScriptHash());
            var sb = new ScriptBuilder();
            sb.EmitAppCall(contractHash, "get", new[] { scriptHash.ToArray() });
            var result = rpcClient.InvokeScriptAsync(sb.ToArray());
            if (result == null || result.Type != StackItemType.Array)
            {
                throw new Exception("Unable to retrieve data");
            }
            return result.GetArray()[0].GetString();
        }
    }
}