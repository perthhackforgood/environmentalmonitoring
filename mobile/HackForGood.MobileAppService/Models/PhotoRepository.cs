using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using HackForGood.MobileAppService.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace HackForGood.Models
{
    public class PhotoRepository : IPhotoRepository
    {
        private static ConcurrentDictionary<string, Photo> photos =
            new ConcurrentDictionary<string, Photo>();
        private static HttpClient _httpClient = new HttpClient();
        private static string _publishEndpoint = "https://phfg-api.azurewebsites.net/api/UploadPhoto";

        public PhotoRepository()
        {
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            //_httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
        }

        public IEnumerable<Photo> GetAll()
        {
            return photos.Values;
        }

        public async void Publish(Photo photo)
        {
            try
            {
                var requestContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(photo), System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(_publishEndpoint, requestContent);

                //"Hello 066f7801-fcb2-4b5e-b33f-634dac26eef8"
                //TODO: This will change but for now, it is as above.

                var responseContent = await response.Content.ReadAsStringAsync();
                var responseContentArray = responseContent.Split(' ');
                photo.Id = responseContentArray[1].Replace("\"", "");
            }
            catch (Exception ex)
            {
                //TODO: Send to AppInsights?

                photo.Id = "Error";
            }

            photos[photo.Id] = photo;
        }

        public Photo Get(string id)
        {
            //TODO: Call Azure Function
            //NOTE: DO NOT TOUCH FOR NOW.
            Photo photo;
            photos.TryGetValue(id, out photo);

            return photo;
        }

        public Photo Remove(string id)
        {
            //TODO: Call Azure Function
            //NOTE: DO NOT TOUCH FOR NOW.
            Photo photo;
            photos.TryRemove(id, out photo);

            return photo;
        }

        public void Update(Photo photo)
        {
            //TODO: Call Azure Function
            //NOTE: DO NOT TOUCH FOR NOW>\.
            photos[photo.Id] = photo;
        }
    }
}
