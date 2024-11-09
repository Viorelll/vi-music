namespace ViMusic.Domain.Entities
{
    public class User : BaseAuditableEntity
    {
        public required string Username { get; set; }
        public required string Email { get; set; }

        public List<Playlist> Playlists { get; set; } = new();
    }
}
