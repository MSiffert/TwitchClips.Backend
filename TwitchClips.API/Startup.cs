using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;
using TwitchClips.API.Abstractions;
using TwitchClips.API.HttpClientDelegationHandler;
using TwitchClips.API.Options;
using TwitchClips.API.Services;

namespace TwitchClips.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private const string CorsPolicyName = "corsPolicy";
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TwitchAuthorizationOptions>(Configuration.GetSection("Twitch"));
            services.AddTransient<LogDelegationHandler>();

            services.AddScoped<ITwitchApiService>(serviceProvider =>
            {
                var httpClient = serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient("twitch");
                
                return new TwitchApiAuthorizationDelegationHandlerService(
                    httpClient,
                    serviceProvider.GetRequiredService<IOptions<TwitchAuthorizationOptions>>(),
                    new TwitchApiService(httpClient)
                );
            });
            
            services.AddHttpClient("twitch").AddHttpMessageHandler<LogDelegationHandler>();

            services.AddMvc().AddNewtonsoftJson();
            
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicyName, builder =>
                {
                    builder.AllowCredentials();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();

                    builder.WithOrigins
                    (
                        "https://localhost:5000", "https://app-twitchclips-ui.azurewebsites.net"
                    );
                });
            });
            
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "";
            });
            
            app.UseRouting();
            app.UseCors(CorsPolicyName);
            
            app.UseEndpoints(endpointRouteBuilder =>
            {
                endpointRouteBuilder.MapControllers();
            });
        }
    }
}
