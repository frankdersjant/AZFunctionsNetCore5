using FunctionAppDependencyInjection.FakeProductDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FunctionAppDependencyInjection
{
    //NOTE - REMOVE the static keyword!!!
    public class AzFunctionDependancyInject
    {
        private IFakeProductDB _fakeDB; 
        public AzFunctionDependancyInject(IFakeProductDB fake)
        {
             _fakeDB =  fake; 
        }

        [Function("AzFunctionDependancyInject")]
        public async Task<IActionResult> GetProduct(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("AzFunctionDependancyInject");
            logger.LogInformation("C# HTTP trigger function: AzFunctionDependancyInject processed a request.");

            var result = await Task.Run(() => _fakeDB.GetProducts());
            //var result = _fakeDB.GetProducts();

            return new OkObjectResult(result);
        }
    }
}
