using FunctionAppDependencyInjection.FakeProductDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace FunctionAppDependencyInjection
{
    //NOTE - REMOVE the static keyword!!!
    public class AzFunctionDependancyInject
    {
        private readonly IFakeProductDB _fakeProductDB; 
        public AzFunctionDependancyInject(IFakeProductDB fakeProductDB)
        {
             _fakeProductDB =  fakeProductDB; 
        }

        [Function("AzFunctionDependancyInject")]
        public async Task<IActionResult> GetMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("AzFunctionDependancyInject");
            logger.LogInformation("C# HTTP trigger function: AzFunctionDependancyInject processed a request.");

            var result = _fakeProductDB.GetProducts();
            return new OkObjectResult(result);
        }
    }
}
