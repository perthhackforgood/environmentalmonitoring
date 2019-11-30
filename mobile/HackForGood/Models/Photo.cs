using System;
using System.Collections.Generic;
using System.Text;

namespace HackForGood.Models
{
    public class Photo
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Filename { get; set; }
        public string ImageAsBase64Str { get; set; }
        public string DeviceId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string TimeOfPhotoTaken { get; set; }
        public double TempOfPhotoTaken { get; set; }
        public string CompassDirectionOfDevice { get; set; }
        public string AddressFromReverseGeoCoding { get; set; }
    }
}
