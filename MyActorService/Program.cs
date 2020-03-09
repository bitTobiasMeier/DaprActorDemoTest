using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Dapr.Actors.AspNetCore;

namespace MyActorService
{
    public class Program
    {
        private const int AppChannelHttpPort = 5001;

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        } 

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseActors(actorRuntime =>
                {
                    // Register MyActor actor type
                    actorRuntime.RegisterActor<MyActor>();
                }
                )
                .UseUrls($"http://localhost:{AppChannelHttpPort}/");
    }
}
