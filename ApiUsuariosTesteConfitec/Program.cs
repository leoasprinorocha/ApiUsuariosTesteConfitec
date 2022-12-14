using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuariosTesteConfitec
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
                     var portExists = int.TryParse(Environment.GetEnvironmentVariable("PORT"), out var port);
                     if (portExists)
                     {
                         webBuilder.ConfigureKestrel(options =>
                         {
                             options.ListenAnyIP(port);
                         });
                     }
                 });
    }
}
