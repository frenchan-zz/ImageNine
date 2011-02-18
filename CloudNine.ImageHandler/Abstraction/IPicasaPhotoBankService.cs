using System.Collections.Generic;
using ImageNine.DataAccess;

namespace ImageNine.Abstraction
{
    public interface IPicasaPhotoBankService
    {
        IList<Album> GetAlbums(string userName);
        IList<Photo> GetPhotos(string userName, string albumId);
        Photo GetPhoto(string userName, string albumId, string photoId);
        void DeletePhoto(string userName, string albumId, string photoId);
        Album CreateNewAlbum(string userName, string albumTitle, string albumSummary);
        void PostNewPhoto(string userName, string albumId, string file);
    }
}
