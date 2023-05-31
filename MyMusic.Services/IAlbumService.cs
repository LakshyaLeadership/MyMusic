namespace MyMusic.Services
{
    public interface IAlbumService
    {
        ViewModels.Album GetAlbumDetails(long albumId);
    }
}