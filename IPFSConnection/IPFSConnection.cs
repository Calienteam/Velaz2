using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace IPFSConnection
{
    public class IPFSConnection
    {
        public async Task<string> UploadDataAsync(byte[] data)
        {
            var http = new HttpClient()
            {
                BaseAddress = new Uri("https://api.pinata.cloud/")
            };

            var form = new MultipartFormDataContent();

            form.Add(new StreamContent(new MemoryStream(data)), "file", "upload.txt");

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("pinning/pinFileToIPFS", UriKind.Relative),
                Content = form,
            };

            request.Headers.Add("pinata_api_key", "6954f39b334d06bccac2");
            request.Headers.Add("pinata_secret_api_key", "90c68fa3d7cc2cc58867abb99be142ae26752dd55854e0974be0d7b3905b9214");

            var response = await http.SendAsync(request);

            var respContent = await response.Content.ReadAsStringAsync();

            var token = JObject.Parse(respContent);

            return token["IpfsHash"].ToString();
        }

        //public async Task<byte[]> StreamVideo(string ipfsHash)
        public async Task<byte[]> GetVideoData64(string ipfsHash)
        {
            var http = new HttpClient()
            {
                BaseAddress = new Uri("https://gateway.ipfs.io/")
            };

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"ipfs/{ipfsHash}", UriKind.Relative)
            };

            var response = await http.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var respContent = await response.Content.ReadAsByteArrayAsync();
          
            return respContent;
        }
    }
}
