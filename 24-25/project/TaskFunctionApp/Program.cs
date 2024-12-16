using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Azure.Identity;;

var host = new HostBuilder()

    .ConfigureFunctionsWebApplication()
    .ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddAzureAppConfiguration(options =>
            {
                var token = new DefaultAzureCredential();
                options.Connect(new Uri(Environment.GetEnvironmentVariable("AppConfig:Endpoint")), token);
                options.ConfigureKeyVault(kv => kv.SetCredential(token));
            });

        })

    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();
