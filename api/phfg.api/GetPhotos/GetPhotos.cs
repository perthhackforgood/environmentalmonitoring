using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using phfg.api.UploadPhotoHttp;

namespace phfgapi
{
    public static class GetPhotos
    {
        [FunctionName("GetPhotos")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            List<StoredPhotoDetails> photoDetails = new List<StoredPhotoDetails>();
        
            photoDetails.Add(
                new StoredPhotoDetails()
                {
                    Id = Guid.NewGuid().ToString(),
                    ImageAsBase64Str = "asdfasgawetaefgq34124152tyser45sert5",
                    DeviceId = "066f7801-fcb2-4b5e-b33f-634dac26eef8",
                    Latitude = -31.95,
                    Longitude = 113.88,
                    TimeOfPhotoTaken = "2019-01-01 10:10:10.000Z",
                    TempOfPhotoTaken = 40.137,
                    CompassDirectionOfDevice = "SW",
                    AddressFromReverseGeoCoding = "10 St Georges Terrace Perth WA 6100"
                });

            photoDetails.Add(
                new StoredPhotoDetails()
                {
                    Id = Guid.NewGuid().ToString(),
                    ImageAsBase64Str = "asdfasgawetaefgq34124152tyser45sert5",
                    DeviceId = "066f7801-fcb2-4b5e-b33f-634dac26eef8",
                    Latitude = -31.95,
                    Longitude = 113.88,
                    TimeOfPhotoTaken = "2019-01-01 10:10:10.000Z",
                    TempOfPhotoTaken = 40.137,
                    CompassDirectionOfDevice = "SW",
                    AddressFromReverseGeoCoding = "10 St Georges Terrace Perth WA 6100"
                });

            var photoDetailsJson = JsonConvert.SerializeObject(photoDetails);

            return new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(photoDetailsJson, Encoding.UTF8, "application/json")
            };
        }
    }
}
