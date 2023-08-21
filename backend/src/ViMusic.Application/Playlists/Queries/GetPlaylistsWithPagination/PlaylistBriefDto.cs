using ViMusic.Application.Common.Mappings;
using ViMusic.Application.Songs.Queries.GetSongsWithPagination;
using ViMusic.Domain.Entities;

namespace ViMusic.Application.Playlists.Queries.GetPlaylistsWithPagination;

public class PlaylistBriefDto : IMapFrom<Playlist>
{
    public int Id { get; init; }

    public string? Name { get; set; }
    public string? CoverImageUrl { get; set; }

    public List<SongBriefDto> Songs { get; set; } = new();
}
