using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace FunctionAppOutPutNet5
{
    public static class OutputNet5
    {
        [Function("OutputNet5")]
        public static MyOutputType MultiOutputSample([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("OutputNet5");
            logger.LogInformation("Started execution of function OutputNet5");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var temp = req.ReadAsString();

            return new MyOutputType()
            {
                Name = temp,
                HttpResponse = response
            };
        }


        public class MyOutputType
        {
            [QueueOutput("testque")]
            public string Name { get; set; }
            public HttpResponseData HttpResponse { get; set; }
        }
    }
}
