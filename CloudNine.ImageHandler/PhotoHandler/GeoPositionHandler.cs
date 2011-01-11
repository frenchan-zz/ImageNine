using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace ImageNine.PhotoHandler
{
    public class GeoPositionHandler
    {
        public string GetPicasaGeoPosition(SyndicationItem item)
        {
            var pos = item.ElementExtensions.Where(ee => ee.OuterName == "where").FirstOrDefault();
            return pos == null ? string.Empty : pos.GetObject<XmlElement>().InnerText;
        }
    }
}
