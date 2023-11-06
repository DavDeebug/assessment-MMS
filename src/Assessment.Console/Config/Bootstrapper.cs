using Assessment.Console.Abstract;
using Assessment.Console.Clients;
using Assessment.Console.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Assessment.Console.Config
{
    public static class Bootstrapper
    {
        const string origin = "http://localhost:5000/";

        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<IReader, Reader>();
            services.AddSingleton<IRetriever, Retriever>();
            services.AddSingleton<IWriter, Writer>();
        }

        public static void AddHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient<AssessmentClient>((client) =>
            {
                client.BaseAddress = new(origin);
            });
        }
    }
}