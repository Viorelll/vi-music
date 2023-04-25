namespace ViMusic.Domain.Entities;

public class Album : BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? CoverImageUrl { get; set; }
    public List<Song> Songs { get; set; } = new();
}
