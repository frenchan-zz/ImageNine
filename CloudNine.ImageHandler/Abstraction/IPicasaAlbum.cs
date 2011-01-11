namespace ImageNine.Abstraction
{
    public interface IPicasaAlbum
    {
        string Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        Access AccessRight { get; set; }
    }
}
