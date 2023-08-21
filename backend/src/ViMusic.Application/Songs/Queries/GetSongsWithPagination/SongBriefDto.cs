using ViMusic.Application.Common.Mappings;
using ViMusic.Domain.Entities;

namespace ViMusic.Application.Songs.Queries.GetSongsWithPagination;

public class SongBriefDto : IMapFrom<Song>
{
    public int Id { get; init; }
    public string? Title { get; init; }
    public string? LocationUrl { get; init; }
    public string? CoverImageUrl { get; init; }
    public string? GenreName { get; init; }
    public string? ArtistName { get; init; }
}
