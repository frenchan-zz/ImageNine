using System.Linq;
using System.ServiceModel.Syndication;

namespace ImageNine.PhotoHandler
{
    public class FeedElementHandler
    {
        public T GetExtensionElementValue<T>(SyndicationItem item, string extensionElementName)
        {
            return item.ElementExtensions.Where(ee => ee.OuterName == extensionElementName).First().GetObject<T>();
        }
    }
}
