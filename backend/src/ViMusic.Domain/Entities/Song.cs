namespace ViMusic.Domain.Entities;
public class Song : BaseAuditableEntity
{
    public string? Title { get; set; }
    public string? LocationUrl { get; set; }
    public string? CoverImageUrl { get; set; }

    public Artist Artist { get; set;} = null!;
    public List<PlaylistSong> Playlists { get; set; } = new();
}
