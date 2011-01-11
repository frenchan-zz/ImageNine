using System.ServiceModel.Syndication;
using System.Xml.Linq;
using ImageNine.Mapper;
using ImageNineTest.Properties;
using NUnit.Framework;

namespace ImageNineTest
{
    [TestFixture]
    public class PicasaPhotoTest
    {
        //private string photoUri;

        [SetUp]
        public void SetUp()
        {
            //photoUri = https://picasaweb.google.com/data/entry/api/user/robertov82/albumid/5490824849223202081/photoid/5491130435749333410;
        }

        [Test]
        public void Given_That_I_Have_Albums_In_My_Photo_Library()
        {
            // Arrange
            var mapper = new PicasaAlbumMapper();

            var xDoc = XDocument.Load(Resources.AlbumFeed);
            
            var feed = SyndicationFeed.Load(xDoc.CreateReader());

            // Act

           var albmus = mapper.GetAlbums(feed);

            // Assert
           Assert.AreEqual(albmus.Count, 3);
        }
    }
}
