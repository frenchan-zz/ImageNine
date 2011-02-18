using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using ImageNine.Abstraction;
using System.ServiceModel.Syndication;
using System.Linq;
using Google.GData.Photos;

namespace ImageNine.DataAccess
{
    public class PicasaPhotoBankRepository : IPicasaPhotoBankRepository
    {
        private readonly string albumUri;
        private readonly string photosUri;
        private readonly string singlePhotoUri;
        private readonly string deletePhotoUri;
        private readonly AuthService service;

        public PicasaPhotoBankRepository(string albumUri, string photosUri, string singlePhotoUri, string deletePhotoUri, AuthService service)
        {
            this.albumUri = albumUri;
            this.photosUri = photosUri;
            this.singlePhotoUri = singlePhotoUri;
            this.deletePhotoUri = deletePhotoUri;
            this.service = service;
        }

        private static readonly object LoadLock = new object();

        public SyndicationFeed GetAlbumsFeed(string userName)
        {
            string url = string.Format(this.albumUri, userName);
               
            lock (LoadLock)
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 5000;
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = XmlReader.Create(url))
                    {
                            return SyndicationFeed.Load<SyndicationFeed>(reader);
                    }
                }
            }
        }

        public SyndicationFeed GetPhotosFeed(string userName, string albumId)
        {
            string url = string.Format(photosUri, userName, albumId);
           
            lock (LoadLock)
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 5000;
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = XmlReader.Create(url))
                    {
                        return SyndicationFeed.Load<SyndicationFeed>(reader);
                    }
                }
            }
        }

        public SyndicationItem GetPhoto(string userName, string albumId, string photoId)
        {
            string url = string.Format(singlePhotoUri, userName, albumId, photoId);

            lock (LoadLock)
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 5000;
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = XmlReader.Create(url))
                    {
                        return SyndicationFeed.Load<SyndicationFeed>(reader).Items.FirstOrDefault();
                    }
                }
            }
        }

        public void DeletePhoto(string userName, string albumId, string photoId)
        {
            string url = string.Format(this.deletePhotoUri, userName, albumId, userName);
            var wc = new WebClient
                         {
                             Encoding = Encoding.UTF8
                         };
            wc.UploadString(url, "delete");
        }

        #region IPicasaPhotoBankRepository Members


        public Google.Picasa.Album CreateNewAlbum(string userName, string albumTitle, string albumSummary)
        {
            var album = new Google.Picasa.Album
                            {
                                Title = albumTitle, 
                                Summary = albumSummary, 
                                Access = "public"
                            };

            var feedUri = new Uri(PicasaQuery.CreatePicasaUri(userName));

            service.Service().Insert(feedUri, album.PicasaEntry);

            return album; 
        }

        public void PostNewPhoto(string userName, string albumId, string file)
        {
            var postUri = new Uri(PicasaQuery.CreatePicasaUri(userName, albumId));

            var fileInfo = new FileInfo(file);
            var fileStream = fileInfo.OpenRead();

            var entry =  service.Service().Insert(postUri, fileStream, "image/" + fileInfo.Extension, file) as PicasaEntry;

            fileStream.Close();

            //Google.Picasa.Photo

            //entry.Exif.

        }

        #endregion
    }
}
