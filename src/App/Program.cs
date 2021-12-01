using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var interceptUri = default(Uri);
            var forwardUri = default(Uri);
            
            do Console.Write("Intercept URL: ");
            while (!Uri.TryCreate(Console.ReadLine(), UriKind.Absolute, out interceptUri));
            
            do Console.Write("Forward URL: ");
            while (!Uri.TryCreate(Console.ReadLine(), UriKind.Absolute, out forwardUri));
            
            Console.WriteLine($"Intercepting URL: {interceptUri} and forwarding to URL: {forwardUri} + query parameters.");

            WebHost
                .CreateDefaultBuilder(args)
                .UseUrls(interceptUri.AbsoluteUri.Replace(interceptUri.AbsolutePath, String.Empty))
                .ConfigureServices(opt => opt.AddMvcCore())
                .Configure(opt =>
                {
                    opt.UseMvc(routeBuilder =>
                        routeBuilder.MapGet(interceptUri.LocalPath, async context =>
                        {
                            var uriBuilder = new UriBuilder(forwardUri);
                            uriBuilder.Query = context.Request.QueryString.Value;
                            context.Response.Redirect(uriBuilder.ToString());
                        }));
                })
                .Build()
                .Run();
        }
    }
}