using Assessment.Console.Abstract;
using Assessment.Console.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Assessment.Console.Config
{
    public static class Bootstrapper
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<IReader, Reader>();
            services.AddSingleton<IRetriever, Retriever>();
            services.AddSingleton<IWriter, Writer>();
        }
    }
}