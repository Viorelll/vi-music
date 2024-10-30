using ViMusic.Domain.Entities;

namespace ViMusic.Domain.Entities;
public class Song : BaseAuditableEntity
{
    public string? Title { get; set; }
    
    public string? Url { get; set; }
    public string? LocationUrl { get; set; }
    public string? CoverImageUrl { get; set; }
    public Genre Genre { get; set;} = null!;
    public Artist Artist { get; set;} = null!;
}
