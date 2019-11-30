using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using HackForGood.MobileAppService.Models;

namespace HackForGood.Models
{
    public class PhotoRepository : IPhotoRepository
    {
        private static ConcurrentDictionary<string, Photo> photos =
            new ConcurrentDictionary<string, Photo>();

        public PhotoRepository()
        {
            //Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Item 1", Description = "This is an item description." });
            //Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Item 2", Description = "This is an item description." });
            //Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Item 3", Description = "This is an item description." });
        }

        public IEnumerable<Photo> GetAll()
        {
            //TODO: Call Azure Function
            return photos.Values;
        }

        public void Publish(Photo photo)
        {
            //TODO: Call Azure Function
            photo.Id = Guid.NewGuid().ToString();
            photos[photo.Id] = photo;
        }

        public Photo Get(string id)
        {
            //TODO: Call Azure Function
            //NOTE: DO NOT TOUCH FOR NOW>\.
            Photo photo;
            photos.TryGetValue(id, out photo);

            return photo;
        }

        public Photo Remove(string id)
        {
            //TODO: Call Azure Function
            //NOTE: DO NOT TOUCH FOR NOW>\.
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
