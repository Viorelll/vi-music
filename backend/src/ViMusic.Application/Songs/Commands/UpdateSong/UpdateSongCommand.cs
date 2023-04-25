using ViMusic.Application.Common.Exceptions;
using ViMusic.Application.Common.Interfaces;
using ViMusic.Domain.Entities;
using MediatR;

namespace ViMusic.Application.Songs.Commands.UpdateSong;

public record UpdateSongCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }
}

public class UpdateSongCommandHandler : IRequestHandler<UpdateSongCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateSongCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateSongCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Songs
           .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
           throw new NotFoundException(nameof(Song), request.Id);
        }

        entity.Title = request.Title;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
