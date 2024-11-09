namespace ViMusic.Domain.Entities;

public class Album : BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? CoverImageUrl { get; set; }

    public Genre Genre { get; set; } = null!;
    public Artist Artist { get; set; } = null!;
}
