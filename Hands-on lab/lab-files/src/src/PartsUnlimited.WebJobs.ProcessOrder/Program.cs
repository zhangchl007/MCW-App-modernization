// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration.Json;
using System.Threading.Tasks;
using PartsUnlimited.Models;
using Microsoft.EntityFrameworkCore;

namespace PartsUnlimited.WebJobs.ProcessOrder
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {                  
            var builder = new HostBuilder();
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddAzureStorage();
            })            
            .ConfigureLogging(b => {
                b.AddConsole();
            })
            .ConfigureAppConfiguration((hostContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true);
                config.AddEnvironmentVariables();
            })
            .ConfigureServices((hostContext, services) => {
                services.AddDbContext<PartsUnlimitedContext>(options => {
                    var configBuilder = new ConfigurationBuilder();
                    configBuilder.Add(new JsonConfigurationSource { Path = "appsettings.json" });
                    var config = configBuilder.Build();
                    var dbConnectionString = config["Data:DefaultConnection:ConnectionString"];

                    if (!string.IsNullOrWhiteSpace(dbConnectionString))
                    {
                        options.UseSqlServer("sqlConnectionString");
                    }
                    else
                    {
                        options.UseInMemoryDatabase("Test");
                    }
                });
            });

            var host = builder.Build();
           
            using (host)
            {
                await host.RunAsync();
            }

            Console.ReadLine();
            return 0;
        }
    }
}
