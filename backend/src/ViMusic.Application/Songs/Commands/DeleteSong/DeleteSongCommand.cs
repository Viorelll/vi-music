using ViMusic.Application.Common.Exceptions;
using ViMusic.Application.Common.Interfaces;
using ViMusic.Domain.Entities;
// using ViMusic.Domain.Events;
using MediatR;

namespace ViMusic.Application.Songs.Commands.DeleteSong;

public record DeleteSongCommand(int Id) : IRequest;

public class DeleteSongCommandHandler : IRequestHandler<DeleteSongCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteSongCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteSongCommand request, CancellationToken cancellationToken)
    {
        //var entity = await _context.Songs
        //    .FindAsync(new object[] { request.Id }, cancellationToken);

        //if (entity == null)
        //{
        //    throw new NotFoundException(nameof(Song), request.Id);
        //}

        //_context.Songs.Remove(entity);

        // entity.AddDomainEvent(new SongDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
