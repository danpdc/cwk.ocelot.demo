using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Cwk.Ocelot.Demo.Gateway
{
    public class Program
    {
        private static IConfiguration _configuration;
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            string ocelotFile = "ocelot.json";
            string appSettingsFile = "appsettings.json";

            return new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                        .AddJsonFile(appSettingsFile, true, true)
                        .AddJsonFile(ocelotFile)
                        .AddEnvironmentVariables();
                    _configuration = config.Build();
                })
                .ConfigureServices(s =>
                {
                    s.AddOcelot(_configuration);
                    IConfigurationSection section = _configuration.GetSection("GatewayOptions");

                    s.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    }).AddJwtBearer("TestKey", options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateLifetime = true,
                            ValidateIssuer = true,
                            ValidIssuer = "DotNet Summit",
                            ValidateAudience = false,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.ASCII.GetBytes(_configuration.GetSection("Authentication")["Secret"])),
                            ValidateActor = false,
                            RequireSignedTokens = true,
                            RequireExpirationTime = false
                        };
                        options.RequireHttpsMetadata = false;
                    });
                    s.AddLogging( p => p.AddConsole());
                })
                .UseIISIntegration()
                .Configure(app =>
                {
                    app.UseOcelot().Wait();
                });
        }
    }
}
