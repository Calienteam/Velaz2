using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var con = new IPFSConnection.IPFSConnection();

            var str = await con.UploadDataAsync(System.Text.Encoding.UTF8.GetBytes("tratata"));

            Assert.IsNotNull(str);
        }

        [Test]
        public async Task Test2()
        {
            var account = new Account("6aad9d4692b13433e57a2909c0150ce4ad988da2860f949f5f0c3ce2669438b6");
            var web3 = new Web3(account, "https://ropsten.infura.io/v3/aebdb8f916a34d23be9a57ea2722417c");

            var lib = new CommonLib.NethereumContract(web3);

            await lib.BuyVideoRequestAsync("", "", "", 0.005m);
        }

        [Test]
        public async Task StreamVideo()
        {
            var connect = new IPFSConnection.IPFSConnection();

            var expected = System.Text.Encoding.UTF8.GetBytes("tratata");

            var fileHash = await connect.UploadDataAsync(expected);

            var actual = await connect.GetVideoData64(fileHash);

            Assert.AreEqual(expected, actual);
        }
    }
}