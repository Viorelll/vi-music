namespace ViMusic.Domain.Entities;

public class Artist : BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public List<Album> Albums { get; set; } = new();
}