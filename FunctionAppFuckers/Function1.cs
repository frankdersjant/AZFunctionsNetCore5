using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionAppFuckers
{
    public static class Function1
    {
        [Function("Function1")]
        [QueueOutput("ordersprocessed")]
        public static void Run([HttpTrigger("myqueue-items", Connection = "")] string myQueueItem,
            FunctionContext context)
        {
            var logger = context.GetLogger("Function1");
            logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
