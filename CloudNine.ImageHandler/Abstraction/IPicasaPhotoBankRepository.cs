using System.ServiceModel.Syndication;

namespace ImageNine.Abstraction
{
    public interface IPicasaPhotoBankRepository
    {
        SyndicationFeed GetAlbumsFeed(string userName);
        SyndicationFeed GetPhotosFeed(string userName, string albumId);
        SyndicationItem GetPhoto(string userName, string albumId, string photoId);
        void DeletePhoto(string userName, string albumId, string photoId);
        Google.Picasa.Album CreateNewAlbum(string userName, string albumTitle, string albumSummary);
        void PostNewPhoto(string userName, string albumId, string file);
    }
}
