using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Playground.Service.LatencyIssue.BLL.Interfaces;
using Playground.Service.LatencyIssue.BLL.Services;

namespace Playground.Service.LatencyIssue
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFakeWorkService, FakeWorkService>();
            services.AddControllers();
            services.AddSwaggerGen();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
