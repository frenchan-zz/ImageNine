using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using ImageNine.DataAccess;

namespace ImageNine.Mapper
{
    public class PicasaPhotosMapper
    {
        private readonly PicasaPhotoMapper photoMapper;

        public PicasaPhotosMapper(PicasaPhotoMapper photoMapper)
        {
            this.photoMapper = photoMapper;
        }

        public IList<Photo> GetPhotos(SyndicationFeed feed)
        {
            return feed.Items.Select(syndicationItem => photoMapper.GetPhoto(syndicationItem)).ToList();
        }
    }
}
