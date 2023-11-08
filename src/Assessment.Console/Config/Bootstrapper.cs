using Assessment.Console.Abstract;
using Assessment.Console.Clients;
using Assessment.Console.Models;
using Assessment.Console.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Assessment.Console.Config
{
    public static class Bootstrapper
    {       
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<IReaderAsync, Reader>();
            services.AddSingleton<IRetrieverAsync, Retriever>();
            services.AddSingleton<IWriterAsync, Writer>();
        }

        public static void AddHttpClients(this IServiceCollection services)
        {            
            services.AddHttpClient<AssessmentClient>((provider, client) =>
            {
                var options = provider.GetRequiredService<IOptionsSnapshot<ClientOptions>>().Value;
                client.BaseAddress = new(options.BaseUrl);
            });
        }

        public static void AddConfiguration(this IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, false)
            .Build();

            services.AddOptions<ReaderOptions>()
            .Bind(config.GetSection(nameof(ReaderOptions)))
            .ValidateDataAnnotations();

            services.AddOptions<WriterOptions>()
            .Bind(config.GetSection(nameof(WriterOptions)))
            .ValidateDataAnnotations();

            services.AddOptions<ClientOptions>()
            .Bind(config.GetSection(nameof(ClientOptions)))
            .ValidateDataAnnotations();
        }
    }
}