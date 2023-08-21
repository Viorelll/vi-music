using ViMusic.Application.Common.Exceptions;
using ViMusic.Application.Common.Interfaces;
using ViMusic.Domain.Entities;
// using ViMusic.Domain.Events;
using MediatR;

namespace ViMusic.Application.Playlists.Commands.DeletePlaylist;

public record DeletePlaylistCommand(int Id) : IRequest;

public class DeletePlaylistCommandHandler : IRequestHandler<DeletePlaylistCommand>
{
    private readonly IApplicationDbContext _context;

    public DeletePlaylistCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeletePlaylistCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Playlists
           .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
           throw new NotFoundException(nameof(Song), request.Id);
        }

        _context.Playlists.Remove(entity);

        // entity.AddDomainEvent(new SongDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
