namespace ImageNine
{
    public interface IAlbum
    {
        string Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        Access AccessRight { get; set; }
    }
}
