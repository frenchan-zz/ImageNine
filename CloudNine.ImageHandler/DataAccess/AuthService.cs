using Google.GData.Photos;

namespace ImageNine.DataAccess
{
    public class AuthService
    {
        private readonly string picasaAppName;
        private readonly string userName;
        private readonly string password;
       
        public AuthService(string picasaAppName, string userName, string password)
        {
            this.picasaAppName = picasaAppName;
            this.userName = userName;
            this.password = password;
        }

        public PicasaService Service()
        {
            var picasaService = new PicasaService(picasaAppName);
            picasaService.setUserCredentials(userName, password);

            return picasaService;
        }
    }
}
