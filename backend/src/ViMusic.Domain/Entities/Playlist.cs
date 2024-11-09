namespace ViMusic.Domain.Entities;

public class Playlist : BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? CoverImageUrl { get; set; }
    public int UserId { get; set; }
    public required User User { get; set; }

    public List<PlaylistSong> Songs { get; set; } = new();
}
