using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace Playground.Service.LatencyIssue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureKestrel(kestrel =>
                    {
                        kestrel.ListenAnyIP(82, options => options.Protocols = HttpProtocols.Http2); //grpc port
                        kestrel.ListenAnyIP(5000, options => options.Protocols = HttpProtocols.Http1AndHttp2); //local http
                        kestrel.ListenAnyIP(80, options => options.Protocols = HttpProtocols.Http1AndHttp2); //kubernates http
                        kestrel.ListenAnyIP(84, options => options.Protocols = HttpProtocols.Http1AndHttp2); //kubernates metrics
                    });
                });
    }
}
