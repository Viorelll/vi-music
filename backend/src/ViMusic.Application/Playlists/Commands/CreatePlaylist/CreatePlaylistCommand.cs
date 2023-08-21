using ViMusic.Application.Common.Interfaces;
using ViMusic.Domain.Entities;
// using ViMusic.Domain.Events;
using MediatR;

namespace ViMusic.Application.Playlists.Commands.CreatePlaylist;

public record CreatePlaylistCommand : IRequest<int>
{
    public string? Name { get; set; }
    public string? CoverImageUrl { get; set; }
}

public class CreatePlaylistCommandHandler : IRequestHandler<CreatePlaylistCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePlaylistCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePlaylistCommand request, CancellationToken cancellationToken)
    {
        var playlist = new Playlist
        {
            Name = request.Name,
            CoverImageUrl = request.CoverImageUrl
        };

        // entity.AddDomainEvent(new SongCreatedEvent(entity));

        _context.Playlists.Add(playlist);

       return await _context.SaveChangesAsync(cancellationToken);
    }
}
