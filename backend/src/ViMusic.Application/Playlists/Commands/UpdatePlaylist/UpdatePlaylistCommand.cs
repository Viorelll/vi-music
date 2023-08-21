using ViMusic.Application.Common.Exceptions;
using ViMusic.Application.Common.Interfaces;
using ViMusic.Domain.Entities;
using MediatR;

namespace ViMusic.Application.Playlists.Commands.UpdatePlaylist;

public record UpdatePlaylistCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; init; }
}

public class UpdatePlaylistCommandHandler : IRequestHandler<UpdatePlaylistCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdatePlaylistCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdatePlaylistCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Playlists
           .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
           throw new NotFoundException(nameof(Song), request.Id);
        }

        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
