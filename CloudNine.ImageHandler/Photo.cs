using System;
using System.Collections.Generic;

namespace ImageNine
{
    public class Photo : IPhoto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PhotoTaken { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string AlbumId { get; set; }

        public virtual List<T> GetPhotos<T>(string userName)
        {
            return new List<T>();
        }
    }
}
