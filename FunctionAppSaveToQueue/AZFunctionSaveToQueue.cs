using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;

namespace FunctionAppSaveToQueue
{
    public static class AzFunctionSaveToQueue
    {

        [Function("AzFunctionSaveToQueue")]
        [QueueOutput("ordersprocessed")]
        public static string Run([QueueTrigger("qdemo", Connection = "")] string orderItem,
            FunctionContext context)
        {

            var logger = context.GetLogger("AzFunctionSaveToQueue");
            logger.LogInformation($" Queue qdemo trigger function processed: {orderItem}");

            return "orderitem : " + orderItem + " processed at " + DateTime.Now;
        }
    }
}
