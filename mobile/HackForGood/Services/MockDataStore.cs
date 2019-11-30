using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackForGood.Models;

namespace HackForGood.Services
{
    public class MockDataStore : IDataStore<Photo>
    {
        List<Photo> items;

        public MockDataStore()
        {
            items = new List<Photo>();
            var mockItems = new List<Photo>
            {
                new Photo { Id = Guid.NewGuid().ToString(), Description="This is an item description." },
                new Photo { Id = Guid.NewGuid().ToString(), Description="This is an item description." },
                new Photo { Id = Guid.NewGuid().ToString(), Description="This is an item description." },
                new Photo { Id = Guid.NewGuid().ToString(), Description="This is an item description." },
                new Photo { Id = Guid.NewGuid().ToString(), Description="This is an item description." },
                new Photo { Id = Guid.NewGuid().ToString(), Description="This is an item description." }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Photo item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Photo item)
        {
            var oldItem = items.Where((Photo arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Photo arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Photo> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Photo>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}