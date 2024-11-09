using ViMusic.Application.Common.Interfaces;
using ViMusic.Domain.Entities;
// using ViMusic.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ViMusic.Application.Playlists.Commands.AddSongToPlaylist;

public record AddSongToPlaylistCommand : IRequest<int>
{
    public int PlaylistId { get; set; }
    public int SongId { get; set; }
}

public class AddSongToPlaylistCommandHandler : IRequestHandler<AddSongToPlaylistCommand, int>
{
    private readonly IApplicationDbContext _context;

    public AddSongToPlaylistCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(AddSongToPlaylistCommand request, CancellationToken cancellationToken)
    {
        var playlist = await _context.Playlists
                .FirstOrDefaultAsync(x => x.Id == request.PlaylistId, cancellationToken);

        if (playlist is null) {
            throw new Exception("Playlist doesn't exist!");
        }

        var song = await _context.Songs
                .FirstOrDefaultAsync(x => x.Id == request.SongId, cancellationToken);

        if (song is null) {
            throw new Exception("Song doesn't exist!");
        }

        var playlistSong = new PlaylistSong
        {
            Playlist = playlist,
            Song = song
        };

        playlist.Songs.Add(playlistSong);

        // entity.AddDomainEvent(new SongCreatedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return 1;
    }
}
