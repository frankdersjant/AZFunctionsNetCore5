using DAL;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

//NOTE: add assembly

[assembly: FunctionsStartup(typeof(AzureFunctionDependencyInjection.Startup))]

namespace AzureFunctionDependencyInjection
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Registering services
            builder
                .Services
                .AddTransient<IDB, FakeDB>();

            //Transient: new service is created everytime they are requested from the service container  
        }
    }
}
