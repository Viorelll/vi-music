namespace ViMusic.Domain.Entities;

public class PlaylistSong : BaseAuditableEntity
{
    public int? PlaylistId { get; set; }
    public Playlist? Playlist { get; set; }
    public int? SongId { get; set; }
    public Song? Song { get; set; }
}
