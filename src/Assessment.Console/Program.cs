using Assessment.Console;
using Assessment.Console.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static System.Console;

using var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddHttpClients();
        services.AddDomainServices();
        services.AddTransient<Worker>();
    })
    .Build();

var app = host.Services.GetRequiredService<Worker>();


while (true)
    try
    {
        app.Work();
    }
    catch (Exception e)
    {
        WriteLine($"An error occurred: {e.Message}");
    }