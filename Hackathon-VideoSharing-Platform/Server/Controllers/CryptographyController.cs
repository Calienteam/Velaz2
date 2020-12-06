using Hackathon.VideoSharing.Platform.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;

namespace Hackathon.VideoSharing.Platform.Server.Controllers
{
    [ApiController]
    [Route("api/crypto")]
    public class CryptographyController : ControllerBase
    {
        [HttpPost]
        [Route("encrypt")]
        public string Encrypt(CryptoRequest req) => Operation(req, false);

        [HttpPost]
        [Route("decrypt")]
        public string Decrypt(CryptoRequest req) => Operation(req, true);

        public string Operation(CryptoRequest req, bool isDecryption)
        {
            Chilkat.Crypt2 crypt = new Chilkat.Crypt2
            {
                CryptAlgorithm = "aes",
                CipherMode = "cbc",
                KeyLength = 256,
                PaddingScheme = 0,
                EncodingMode = "hex"
            };

            var data = Convert.FromBase64String(req.Data64);
            crypt.SetSecretKeyViaPassword(req.Password);

            var operated = isDecryption ? crypt.DecryptBytes(data) : crypt.EncryptBytes(data);

            return Convert.ToBase64String(operated);
        }

        [HttpGet]
        [Route("rsa-keys")]
        public PublicPrivateKey GetKeys()
        {
            Chilkat.Rsa rsa = new Chilkat.Rsa();
            rsa.GenerateKey(1024);

            string publicKey = rsa.ExportPublicKey();
            string privateKey = rsa.ExportPrivateKey();

            var data = new PublicPrivateKey()
            {
                PrivateKey = privateKey,
                PublicKey = publicKey
            };

            return data;
        }

        [HttpPost]
        [Route("encrypt-rsa")]
        public byte[] EncryptWithPublic(CryptoRequest cryptoRequest)
        {
            var bytes64 = cryptoRequest.Data64;
            var publicKey = cryptoRequest.Password;

            byte[] bytes = Convert.FromBase64String(bytes64);

            Chilkat.Rsa rsaEncryptor = new Chilkat.Rsa
            {
                EncodingMode = "hex"
            };

            rsaEncryptor.ImportPublicKey(publicKey);

            return rsaEncryptor.EncryptBytes(bytes, usePrivateKey: false);
        }

        [HttpPost]
        [Route("decrypt-rsa")]
        public byte[] DecryptWithPrivate(CryptoRequest cryptoRequest)
        {
            var bytes64 = cryptoRequest.Data64;
            var privateKey = cryptoRequest.Password;

            byte[] bytes = Convert.FromBase64String(bytes64);

            Chilkat.Rsa rsaEncryptor = new Chilkat.Rsa
            {
                EncodingMode = "hex"
            };

            rsaEncryptor.ImportPrivateKey(privateKey);

            return rsaEncryptor.DecryptBytes(bytes, usePrivateKey: true);
        }
    }
}
