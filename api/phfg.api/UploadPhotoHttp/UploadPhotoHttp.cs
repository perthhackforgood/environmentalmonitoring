using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace phfg.api.UploadPhotoHttp
{
    public static class UploadPhotoHttp
    {
        [FunctionName("UploadPhoto")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]
            HttpRequestMessage req, 
            TraceWriter log,
            [Blob("sample-images-md/{name}", FileAccess.Write)] Stream rawImages)
        {
            log.Info("C# HTTP trigger function processed a request.");
            PhotoDetails photo = (PhotoDetails)await req.Content.ReadAsAsync<PhotoDetails>();

            return photo == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                : req.CreateResponse(HttpStatusCode.OK, "Hello " + photo.DeviceId);
        }
    }
}
