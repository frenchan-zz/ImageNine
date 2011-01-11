using System;
using Google.GData.Photos;
using Google.GData.Client;
using ImageNine;

namespace Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;


            var list = PicasaAlbum.GetAlbums(userName);

            repAlbums.DataSource = list;
            repAlbums.DataBind();

            var photos = PicasaPhoto.GetPhotos(userName, "5490825381803270241");

            repPhots.DataSource = photos;
            repPhots.DataBind();

            Response.Write(PicasaPhoto.PicasaTest());
        }
    }
}
