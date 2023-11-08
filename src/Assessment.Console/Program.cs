using Assessment.Console;
using Assessment.Console.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static System.Console;

using var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddConfiguration();
        services.AddHttpClients();

        services.AddDomainServices();
        services.AddTransient<Worker>();
    })
    .Build();

string? path;
var app = host.Services.GetRequiredService<Worker>();

while (true)
    try
    {        
        do
        {
            WriteLine("Please enter a valid path, for txt template");
            path = ReadLine();
        } while (string.IsNullOrEmpty(path) || path.Length < 3);
        
        await app.Work(path);
    }
    catch (Exception e)
    {
        WriteLine($"An error occurred: {e.Message}");
    }