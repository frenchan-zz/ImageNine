using System;
using System.ServiceModel.Syndication;
using ImageNine.DataAccess;
using ImageNine.PhotoHandler;

namespace ImageNine.Mapper
{
    public class PicasaPhotoMapper
    {
        private readonly FeedElementHandler elementHandler;
        private readonly TimeStampFormatter timeStampFormatter;
        private readonly GeoPositionHandler geo;

        public PicasaPhotoMapper(FeedElementHandler elementHandler, TimeStampFormatter timeStampFormatter, GeoPositionHandler geo)
        {
            this.elementHandler = elementHandler;
            this.timeStampFormatter = timeStampFormatter;
            this.geo = geo;
        }

        public Photo GetPhoto(SyndicationItem item)
        {
            string position = this.geo.GetPicasaGeoPosition(item);

            string rawTimeStamp = elementHandler.GetExtensionElementValue<string>(item, "timestamp");
            rawTimeStamp = rawTimeStamp.Replace("000", "");

            double timeStamp;
            var photoDate = new DateTime();

            if (double.TryParse(rawTimeStamp, out timeStamp))
            {
                photoDate = timeStampFormatter.UnixTimeStampToDateTime(timeStamp);
            }

            var photo = new Photo()
            {
                Id = elementHandler.GetExtensionElementValue<string>(item, "id"),
                AlbumId = elementHandler.GetExtensionElementValue<string>(item, "albumid"),
                Title = item.Title.Text,
                Description = item.Summary.Text,
                PhotoTaken = photoDate,
                Width = elementHandler.GetExtensionElementValue<int>(item, "width"),
                Height = elementHandler.GetExtensionElementValue<int>(item, "height"),
                Longitude = position[0].ToString(),
                Latitude = position[1].ToString(),
                PhotoHref = ((UrlSyndicationContent)item.Content).Url.OriginalString
            };

            return photo;
        }
    }
}
