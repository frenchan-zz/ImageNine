using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using Google.GData.Photos;
using ImageNine.DataAccess;

namespace ImageNine.Mapper
{
    public class PicasaAlbumMapper
    {
        public IList<Album> GetAlbums(SyndicationFeed feed)
        {
            var albumList = new List<Album>();

            foreach (var syndicationItem in feed.Items)
            {
                var picasaQuery = new PicasaQuery(syndicationItem.Id);

                var album = new Album()
                                {
                                    Id = picasaQuery.Uri.Segments.LastOrDefault(),
                                    Title = syndicationItem.Title.Text,
                                    Description = syndicationItem.Summary.Text
                                };

                albumList.Add(album);
            }

            return albumList;
        }

        public Album GetAlbum(Google.Picasa.Album picasaAlbum)
        {
            var album = new Album()
                            {
                                Id = picasaAlbum.Id,
                                Description = picasaAlbum.Summary,
                                Title = picasaAlbum.Title
                            };

            return album;
        }
    }
}
