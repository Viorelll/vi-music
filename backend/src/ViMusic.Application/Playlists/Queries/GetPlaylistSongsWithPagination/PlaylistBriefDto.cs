using ViMusic.Application.Common.Mappings;
using ViMusic.Application.Songs.Queries.GetSongsWithPagination;
using ViMusic.Domain.Entities;

namespace ViMusic.Application.Playlists.Queries.GetPlaylistSongsWithPagination;

public class PlaylistSongsBriefDto : IMapFrom<Playlist>
{
    public int Id { get; init; }
    public string? Name { get; set; }
    public string? CoverImageUrl { get; set; }
    public List<PlaylistSongBriefDto> Songs { get; set; } = new();
}

public class PlaylistSongBriefDto : IMapFrom<PlaylistSong>
{
    public SongBriefDto Song { get; set; }
}

