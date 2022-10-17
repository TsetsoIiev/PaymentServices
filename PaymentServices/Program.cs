using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaymentServices;
using PaymentServices.Data;
using PaymentServices.Types;


IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var dataStoreOpts = config.GetRequiredSection("DataStoreTypeOptions").Get<DataStoreTypeOptions>();

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostingContext, services) =>
    {
        if (dataStoreOpts.DataStoreType == StringConstants.BACKUP_DATA_STORE)
            services.AddTransient<IAccountDataStore, BackupAccountDataStore>();
        else
            services.AddTransient<IAccountDataStore, AccountDataStore>();
    })
    .Build();

await host.RunAsync();