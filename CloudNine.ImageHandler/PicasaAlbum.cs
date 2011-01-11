using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Web;
using System.Xml;
using Google.GData.Photos;

namespace ImageNine
{
    public class PicasaAlbum
    {
        //public Access AccessRight { get; set; }

        //private readonly HttpContextBase httpContext;
        //private static readonly string AlbumUri = ImageNineSettings.Default.AlbumUri;

        //public PicasaAlbum(SyndicationItem si)
        //{
        //    var picasaQuery = new PicasaQuery(si.Id);

        //    this.Id = picasaQuery.Uri.Segments.LastOrDefault();
        //    this.Title = si.Title.Text;
        //    this.Description = si.Summary.Text;
        //}

        //public PicasaAlbum(HttpContextBase httpContext)
        //{
        //    this.httpContext = httpContext;
        //}

        //private static readonly object LoadLock = new object();

        ///// <summary>
        ///// Gets the albums.
        ///// </summary>
        ///// <param name="userName">Name of the user.</param>
        ///// <returns></returns>
        //public IList<PicasaAlbum> GetAlbums(string userName)
        //{
        //    string url = string.Format(AlbumUri, userName);

        //    IList<PicasaAlbum> list = this.httpContext.Cache[url] as List<PicasaAlbum>;

        //    try
        //    {
        //        if (list == null)
        //        {
        //            lock (LoadLock)
        //            {
        //                list = this.httpContext.Cache[url] as List<PicasaAlbum>;
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
        //                                list = (from ti in feed.Items
        //                                        select new PicasaAlbum(ti)).ToList();
        //                            //5min cache
        //                            if (list != null)
        //                                this.httpContext.Cache.Add(url, list, null,
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
        //        list = new List<PicasaAlbum>();

        //        this.httpContext.Cache.Add(url, list, null, DateTime.Now.AddMinutes(5),
        //                                            System.Web.Caching.Cache.NoSlidingExpiration,
        //                                            System.Web.Caching.CacheItemPriority.Normal, null);
        //    }
        //    return list;
        //}
    }
}
