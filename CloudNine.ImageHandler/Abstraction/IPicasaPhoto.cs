using System;

namespace ImageNine.Abstraction
{
    public interface IPicasaPhoto
    {
        string Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string PhotoHref { get; set; }
        DateTime? PhotoTaken { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        string Longitude { get; set; }
        string Latitude { get; set; }
        string AlbumId { get; set; }
        Access PhotoAccess { get; set; }
        //T Thumbnails<T>(){ get; set; }
    }
}
