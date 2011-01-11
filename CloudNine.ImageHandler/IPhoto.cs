using System;

namespace ImageNine
{
    interface IPhoto
    {
        string Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        DateTime? PhotoTaken { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        string AlbumId { get; set; }
    }   
}
