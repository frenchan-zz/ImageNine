using ImageNine.Abstraction;
using ImageNine.DataAccess;
using StructureMap.Configuration.DSL;

namespace ImageNine.Web.Configuration 
{
    public class WebRegistry : Registry
    {
       public WebRegistry()
       {
           For<AuthService>()
               .Use<AuthService>()
               .Ctor<string>("picasaAppName")
               .Is("My Picasa App")
               .Ctor<string>("userName")
               .Is("xxx")
               .Ctor<string>("password")
               .Is("xxx");

           For<IPicasaPhotoBankRepository>()
               .Use<PicasaPhotoBankRepository>()
               .Ctor<string>("albumUri")
               .Is(Properties.Settings.Default.AlbumUri)
               .Ctor<string>("photosUri")
               .Is(Properties.Settings.Default.AlbumPhotosUri)
               .Ctor<string>("singlePhotoUri")
               .Is(Properties.Settings.Default.PhotoUri)
               .Ctor<string>("deletePhotoUri")
               .Is(Properties.Settings.Default.DeletePhotoUri);
           
           For<IPicasaPhotoBankService>()
               .Use<PicasaPhotoBankService>();
       }
    }
}