namespace ViMusic.Domain.Entities;

public class Genre : BaseAuditableEntity {

    public string? Name { get; set; }
    public string? Description { get; set; }
}