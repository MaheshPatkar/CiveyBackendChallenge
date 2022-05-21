using System;
using CiveyWeb.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CiveyWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (bool.TryParse(Environment.GetEnvironmentVariable("DBInit"), out var dbInitFlag) &&  dbInitFlag)
            {
                DbInitializer.Initialize();
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}