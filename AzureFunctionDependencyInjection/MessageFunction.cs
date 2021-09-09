using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AzureFunctionDependencyInjection
{
    //Note:  static removed!!!
    public class MessageFunction
    {
        private IDB _dB;

        public MessageFunction(IDB dB)
        {
            _dB = dB;
        }

        [FunctionName("hithere")]
        public async Task<IActionResult> GetMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var result = _dB.GetProducts();
            return new OkObjectResult(result);
        }
    }
}
