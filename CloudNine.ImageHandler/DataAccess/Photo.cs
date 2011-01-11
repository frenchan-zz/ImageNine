using System;

namespace ImageNine.DataAccess
{
    public class Photo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoHref { get; set; }
        public DateTime? PhotoTaken { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string AlbumId { get; set; }
    }
}
