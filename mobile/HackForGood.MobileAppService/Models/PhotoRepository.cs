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

        public PhotoRepository()
        {
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
        }

        public IEnumerable<Photo> GetAll()
        {
            return photos.Values;
        }

        public async void Publish(Photo photo)
        {
            //TODO: Call Azure Function
            var request = new HttpRequestMessage();

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            photo.Id = Guid.NewGuid().ToString();
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
