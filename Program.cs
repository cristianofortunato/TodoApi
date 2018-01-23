using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TodoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
        BuildWebHost(args).Run();
/* 
             var configuration = new ConfigurationBuilder()
            .AddCommandLine(args)
            .Build();

        var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseConfiguration(configuration)
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build();

        host.Run();
   
   */
        }
        

        public static IWebHost BuildWebHost(string[] args) {
            var port = Environment.GetEnvironmentVariable("PORT");
            var address = Environment.GetEnvironmentVariable("ADDRESS");
            if (port == null || address == null) {
                 throw new System.ArgumentException("Environment variables PORT and ADDRESS cannot be null");
            }            
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://"+address+":"+port)
                .Build();
        }
    }
}
