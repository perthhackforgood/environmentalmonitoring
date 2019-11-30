using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;

namespace phfg.api.UploadPhotoHttp
{
    public static class UploadPhotoHttp
    {
        [FunctionName("UploadPhoto")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]
            HttpRequestMessage req,
            [Blob("raw/new", FileAccess.Write, Connection = "StorageBlobConnectionString")] CloudBlobContainer outputContainer,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed an upload photo request.");

            try
            {
                PhotoDetails photo = (PhotoDetails)await req.Content.ReadAsAsync<PhotoDetails>();

                if (photo == null)
                    return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body");

                var bytes = Convert.FromBase64String(photo.ImageAsBase64Str);

                var outputImage = new MemoryStream(bytes);
                
                //NOTE: Bindings for some reason seem to error when you specify "{name}".
                var blob = outputContainer.GetBlockBlobReference($"{photo.Filename}");
                await blob.UploadFromStreamAsync(outputImage);

                return req.CreateResponse(HttpStatusCode.OK, "Hello " + photo.DeviceId);
            }
            catch (Exception ex)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "No");
            }
        }
    }

    public class PhotoDetails
    {
        public string ImageAsBase64Str { get; set; }
        public string DeviceId { get; set; }
        public string Filename { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string TimeOfPhotoTaken { get; set; }
        public double TempOfPhotoTaken { get; set; }
        public string CompassDirectionOfDevice { get; set; }
        public string AddressFromReverseGeoCoding { get; set; }
    }
}