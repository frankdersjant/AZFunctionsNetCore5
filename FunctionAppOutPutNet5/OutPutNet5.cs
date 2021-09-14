using FunctionAppOutPutNet5.DTO;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace FunctionAppOutPutNet5
{
    public static class OutputNet5
    {
        [Function("OutputNet5")]
        public static async Task<CustomOutputType> MultiOutputSample(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("OutputNet5");
            logger.LogInformation("Started execution of function");

            var data = await req.ReadFromJsonAsync<UserDTO>();

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteStringAsync($"Hello {data.Name}, Welcome to Output Bindings");


            //return new CustomOutputType
            //{
            //    UserResponse = response,
            //    UserTask = $"{data.Name} have logged in"
            //};
        }


        public class CustomOutputType
        {
           // [QueueOutput("SampleQueue")]
            public string UserTask { get; set; }
            public HttpResponseData UserResponse { get; set; }
        }
    }
}
