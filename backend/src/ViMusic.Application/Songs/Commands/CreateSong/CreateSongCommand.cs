using ViMusic.Application.Common.Interfaces;
using ViMusic.Domain.Entities;
// using ViMusic.Domain.Events;
using MediatR;

namespace ViMusic.Application.Songs.Commands.CreateSong;

public record CreateSongCommand : IRequest<int>
{
    public string? Title { get; init; }
    public string? LocationUrl { get; init; }
    public string? CoverImageUrl { get; init; }
    public string? GenreName { get; init; }
    public string? GenreDescription { get; init; }
    public string? ArtistName { get; init; }
    public string? ArtistImageUrl { get; init; }
}

public class CreateSongCommandHandler : IRequestHandler<CreateSongCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSongCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSongCommand request, CancellationToken cancellationToken)
    {
        var genre = new Genre
        {
            Name = request.GenreName,
            Description = request.GenreDescription
        };

        var artist = new Artist
        {
           Name = request.ArtistName,
           ImageUrl = request.ArtistImageUrl
        };

        var song = new Song
        {
           Title = request.Title,
           LocationUrl = request.LocationUrl,
           CoverImageUrl = request.CoverImageUrl,
           Artist = artist,
           Genre = genre
        };

        // entity.AddDomainEvent(new SongCreatedEvent(entity));

        _context.Songs.Add(song);

        await _context.SaveChangesAsync(cancellationToken);

        return 1;
    }
}
