using CommonLib;
using Hackathon.VideoSharing.Platform.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hackathon_VideoSharing_Platform.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton<IMetamaskInterop, MetamaskBlazorInterop>();
            builder.Services.AddSingleton<MetamaskService>();
            builder.Services.AddSingleton<MetamaskInterceptor>();

            builder.Services.AddSingleton<SymmetricKeyIPFSDictionary>();

            await builder.Build().RunAsync();
        }
    }
}
