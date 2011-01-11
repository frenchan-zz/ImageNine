using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Web;
using System.Xml;
using Google.GData.Photos;
using ImageNine.Abstraction;
using ImageNine.Settings;

namespace ImageNine
{
    public class PicasaPhoto
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
        public Access PhotoAccess { get; set; }
        public PicasaPhotoSize Thumbnails { get; set; }

        private static readonly string photoUri = ImageNineSettings.Default.AlbumPhotosUri;

        public PicasaPhoto()
        {
        }

        //public PicasaPhoto(SyndicationItem item)
        //{

        //    this.Id = GetExtensionElementValue<string>(item, "id");
        //    this.Title = item.Title.Text;
        //    this.Description = item.Summary.Text;
        //    this.Width = GetExtensionElementValue<int>(item, "width");
        //    this.Height = GetExtensionElementValue<int>(item, "width");
        //    this.AlbumId = GetExtensionElementValue<string>(item, "albumid");
        //    //this.PhotoAccess = (Access)Enum.Parse(typeof(Access), GetExtensionElementValue<string>(item, "access"));

        //    string position = GetGeoPos(item);

        //    if (!string.IsNullOrEmpty(position))
        //    {
        //        this.Longitude =position.Split(' ')[1];
        //        this.Latitude = position.Split(' ')[0];
        //    }
        
        //    this.PhotoHref = ((UrlSyndicationContent) item.Content).Url.OriginalString;
        //    this.Thumbnails = new PicasaPhotoSize(this.PhotoHref);
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="PicasaPhoto"/> class.
        /// </summary>
        /// <param name="photo">The photo.</param>
        public PicasaPhoto(Google.Picasa.Photo photo)
        {
            this.Id = photo.Id;
            this.Title = photo.Title;
            this.Description = photo.Summary;
            this.Width = photo.Width;
            this.Height = photo.Height;
            this.AlbumId = photo.AlbumId;
            this.Longitude = photo.Longitude.ToString();
            this.Latitude = photo.Latitude.ToString();
            this.PhotoHref = photo.PhotoUri.AbsoluteUri;
            this.Thumbnails = new PicasaPhotoSize(photo.PhotoUri.AbsoluteUri);
        }

        //private static readonly object LoadLock = new object();

        /// <summary>
        /// Gets the photos.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="albumId">The album id.</param>
        /// <returns></returns>
        //public static IList<PicasaPhoto> GetPhotos(string userName, string albumId)
        //{
        //    string url = string.Format(photoUri, userName, albumId);

        //    IList<PicasaPhoto> list = HttpContext.Current.Cache[url] as List<PicasaPhoto>;

        //    try
        //    {
        //        if (list == null)
        //        {
        //            lock (LoadLock)
        //            {
        //                list = HttpContext.Current.Cache[url] as List<PicasaPhoto>;
        //                if (list == null)
        //                {
        //                    var request = (HttpWebRequest)WebRequest.Create(url);
        //                    request.Timeout = 5000;
        //                    using (var response = (HttpWebResponse)request.GetResponse())
        //                    {
        //                        using (var reader = XmlReader.Create(url))
        //                        {
        //                            var feed = SyndicationFeed.Load<SyndicationFeed>(reader);


        //                            if (feed != null)
        //                            {
        //                                //var si = (from ti in feed.Items)
        //                                list = (from item in feed.Items
        //                                        select new PicasaPhoto(item)).ToList();
        //                            }
        //                            //5min cache
        //                            if (list != null)
        //                                HttpContext.Current.Cache.Add(url, list, null,
        //                                                                DateTime.Now.AddMinutes(5),
        //                                                                System.Web.Caching.Cache.
        //                                                                    NoSlidingExpiration,
        //                                                                System.Web.Caching.CacheItemPriority.
        //                                                                    Normal, null);
        //                        }
        //                    }
        //                }
        //            }

        //        }
        //    }
        //    catch (WebException)
        //    {
        //        list = new List<PicasaPhoto>();

        //        HttpContext.Current.Cache.Add(url, list, null, DateTime.Now.AddMinutes(5),
        //                                            System.Web.Caching.Cache.NoSlidingExpiration,
        //                                            System.Web.Caching.CacheItemPriority.Normal, null);
        //    }
        //    return list;
        //}

        ///// <summary>
        ///// Gets the photo by id.
        ///// </summary>
        ///// <param name="service">The service.</param>
        ///// <param name="photoId">The photo id.</param>
        ///// <returns></returns>
        //public static PicasaPhoto GetPhotoById(AuthService service, string photoId)
        //{
        //    PicasaPhoto photo = null;

        //    var photoQuery = new PhotoQuery(PicasaQuery.CreatePicasaUri(service.UserName));

        //    var photoFeed = service.Service.Query(photoQuery);

        //    foreach (var entry in photoFeed.Entries)
        //    {
        //        var pa = new Google.Picasa.Photo {AtomEntry = entry};

        //        if (pa.Id == photoId)
        //        {
        //            photo = new PicasaPhoto(pa);
        //        }
        //    }

        //    return photo;
        //}

        //public static void MovePhotoToOtherAlbum(string albumId, PicasaPhoto photo)
        //{
        //    if (photo == null)
        //    {
        //        return;
        //    }
            

        //}

        /// <summary>
        /// Gets the extension element value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="extensionElementName">Name of the extension element.</param>
        /// <returns></returns>
        private static T GetExtensionElementValue<T>(SyndicationItem item, string extensionElementName)
        {
            return item.ElementExtensions.Where(ee => ee.OuterName == extensionElementName).First().GetObject<T>();
        }

        /// <summary>
        /// Gets the geo pos.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        private static string GetGeoPos(SyndicationItem item)
        {
            var pos = item.ElementExtensions.Where(ee => ee.OuterName == "where").FirstOrDefault();
            return pos == null ? string.Empty : pos.GetObject<XmlElement>().InnerText;
        }
    }
}
