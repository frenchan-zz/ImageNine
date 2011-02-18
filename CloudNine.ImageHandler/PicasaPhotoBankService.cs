using System.Collections.Generic;
using ImageNine.Abstraction;
using ImageNine.DataAccess;
using ImageNine.Mapper;

namespace ImageNine
{
    public class PicasaPhotoBankService : IPicasaPhotoBankService
    {
        private readonly IPicasaPhotoBankRepository photoBankRepository;
        private readonly PicasaAlbumMapper albumMapper;
        private readonly PicasaPhotosMapper photosMapper;
        private readonly PicasaPhotoMapper photoMapper;

        public PicasaPhotoBankService(IPicasaPhotoBankRepository photoBankRepository, PicasaAlbumMapper albumMapper, PicasaPhotosMapper photosMapper, PicasaPhotoMapper photoMapper)
        {
            this.photoBankRepository = photoBankRepository;
            this.albumMapper = albumMapper;
            this.photosMapper = photosMapper;
            this.photoMapper = photoMapper;
        }

        public IList<Album> GetAlbums(string userName)
        {
            var feed = photoBankRepository.GetAlbumsFeed(userName);
            return albumMapper.GetAlbums(feed);
        }

        public IList<Photo> GetPhotos(string userName, string albumId)
        {
            var feed = photoBankRepository.GetPhotosFeed(userName, albumId);
            
            return photosMapper.GetPhotos(feed);
        }

        public Photo GetPhoto(string userName, string albumId, string photoId)
        {
            var item = photoBankRepository.GetPhoto(userName, albumId, photoId);

            return photoMapper.GetPhoto(item);
        }

        public void DeletePhoto(string userName, string albumId, string photoId)
        {
            photoBankRepository.DeletePhoto(userName, albumId, photoId);
        }

        public Album CreateNewAlbum(string userName, string albumTitle, string albumSummary)
        {
            var album = photoBankRepository.CreateNewAlbum(userName, albumTitle, albumSummary);
            return albumMapper.GetAlbum(album);
        }

        public void PostNewPhoto(string userName, string albumId, string file)
        {
            photoBankRepository.PostNewPhoto(userName, albumId, file);
        }
    }
}
