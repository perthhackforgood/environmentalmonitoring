using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using HackForGood.Models;

namespace HackForGood.Services
{
    public class AzureDataStore : IDataStore<Photo>
    {
        HttpClient client;
        IEnumerable<Photo> photos;

        public AzureDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            photos = new List<Photo>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<Photo>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"api/item");
                photos = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Photo>>(json));
            }

            return photos;
        }

        public async Task<Photo> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"api/item/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Photo>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Photo photo)
        {
            if (photo == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(photo);

            var response = await client.PostAsync($"api/item", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(Photo photo)
        {
            if (photo == null || photo.Id == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(photo);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/item/{photo.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/item/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
