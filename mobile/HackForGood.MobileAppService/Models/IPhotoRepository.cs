using HackForGood.MobileAppService.Models;
using System;
using System.Collections.Generic;

namespace HackForGood.Models
{
    public interface IPhotoRepository
    {
        void Publish(Photo photo);
        void Update(Photo photo);
        Photo Remove(string key);
        Photo Get(string id);
        IEnumerable<Photo> GetAll();
    }
}
