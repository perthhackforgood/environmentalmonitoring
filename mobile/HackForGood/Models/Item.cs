using System;
using Xamarin.Essentials;

namespace HackForGood.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Filename { get; internal set; }
        public Location Location { get; internal set; }

        public DateTime CaptureTime { get; set; }
    }
}