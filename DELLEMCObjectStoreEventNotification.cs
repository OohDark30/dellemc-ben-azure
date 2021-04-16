using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ECSBucketEventNotification
{
    public static class DELLEMCObjectStoreEventNotification
    {
        [FunctionName("DELLEMCObjectStoreEventNotification")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("Azure Functions: DELLEMC::ObjectScale - WebHook Received a Bucket Notification Event from a DELL EMC ObjectStore.");

            // Grab the name parameter if provided
            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<DELLEMCS3BucketEventData>(requestBody);

            // Grab data from the event you're interested in
            var Records = data.Records;
            DELLEMCS3BucketEvent eventRecord = Records[0];
            DELLEMCEventS3 eventS3 = eventRecord.S3;
            DELLEMCS3Bucket eventS3Bucket = eventS3.Bucket;
            DELLEMCS3Object eventS3Object = eventS3.Object;

            log.LogInformation("Azure Functions: DELLEMC::ObjectScale Bucket Notification Event Received for: " +
                "\n\tEvent Time: " + eventRecord.eventTime +
                "\n\tEvent Source: " + eventRecord.eventSource +
                "\n\tEvent Region: " + eventRecord.awsRegion +
                "\n\tEvent Name: " + eventRecord.eventName +
                "\n\tEvent Source IP: " + eventRecord.requestParameters.sourceIPAddress +
                "\n\tEvent Principal ID: " + eventRecord.userIdentity.principalId +
                "\n\tBucket Name: " + eventS3Bucket.name +
                "\n\tBucket ARN: " + eventS3Bucket.arn +
                "\n\tBucket Owner ID: " + eventS3Bucket.ownerIdentity.principalId +
                "\n\tObject Key: " + eventS3Object.key +
                "\n\tObject Size: " + eventS3Object.size +
                "\n\tObject eTag: " + eventS3Object.etag +
                "\n\tObject Version ID: " + eventS3Object.versionId +
                "\n\tObject Sequencer: " + eventS3Object.sequencer
                );

            string responseMessage = "Azure Functions: DELLEMC::ObjectScale Bucket Notification Event Successfully Processed";

            return new OkObjectResult(responseMessage);
        }
    }


}

