namespace phfg.api.UploadPhotoHttp
{
    public class PhotoDetails
    {
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