using System;
using ImageNine.Abstraction;
using ImageNine.Web.Development;

namespace ImageNine.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        private readonly IPicasaPhotoBankService service = ServiceLocator.GetService<IPicasaPhotoBankService>();

        protected void Page_Load(object sender, EventArgs e)
        {
            service.CreateNewAlbum("robertov82", "Mongo", "Grym album");
           // service.DeletePhoto("robertov82", "5490824849223202081", "5491130435749333410");
        }
    }
}