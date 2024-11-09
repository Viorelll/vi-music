using ViMusic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ViMusic.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Song> Songs { get; }
    DbSet<Playlist> Playlists { get; }
    DbSet<PlaylistSong> PlaylistSongs { get; }
    DbSet<Album> Albums { get; }
    DbSet<Artist> Artists { get; }
    DbSet<Genre> Genres { get; }
    DbSet<User> Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
