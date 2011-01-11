namespace ImageNine
{
    public class PicasaPhotoSize
    {
        public string Thumbnails72 { get; private set; }

        public string Thumbnails144 { get; private set; }

        public string Thumbnails288 { get; private set; }

        public string CustomThumbnailSize { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PicasaPhotoSize"/> class.
        /// </summary>
        /// <param name="originalUri">The original URI.</param>
        /// <param name="width">The width.</param>
        public PicasaPhotoSize(string originalUri, int width)
        {
            this.CustomThumbnailSize = GetThumbnailSize(originalUri, width);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PicasaPhotoSize"/> class.
        /// </summary>
        /// <param name="originalUri">The original URI.</param>
        public PicasaPhotoSize(string originalUri)
        {
            this.Thumbnails72 = GetThumbnailSize(originalUri, 72);
            this.Thumbnails144 = GetThumbnailSize(originalUri, 144);
            this.Thumbnails288 = GetThumbnailSize(originalUri, 288);
        }

        /// <summary>
        /// Gets the size of the thumbnail.
        /// </summary>
        /// <param name="originalUri">The original URI.</param>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public static string GetThumbnailSize(string originalUri, int width)
        {
            if (!string.IsNullOrEmpty(originalUri) && originalUri.Contains("/"))
            {
                int length = originalUri.LastIndexOf("/");

                string newThumbnail = originalUri.Insert(length, string.Format("/s{0}", width));

                return newThumbnail;
            }
            return string.Empty;
        }
    }
}
