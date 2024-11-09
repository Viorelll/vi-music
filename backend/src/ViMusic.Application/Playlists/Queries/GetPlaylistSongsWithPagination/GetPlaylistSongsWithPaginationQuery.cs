using AutoMapper;
using AutoMapper.QueryableExtensions;
using ViMusic.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ViMusic.Application.Playlists.Queries.GetPlaylistsWithPagination;

namespace ViMusic.Application.Playlists.Queries.GetPlaylistSongsWithPagination;

public record GetPlaylistSongsWithPaginationQuery : IRequest<PlaylistSongsBriefDto>
{
    public int Id { get; set; }
}

public class GetPlaylistSongsWithPaginationQueryHandler : IRequestHandler<GetPlaylistSongsWithPaginationQuery, PlaylistSongsBriefDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPlaylistSongsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PlaylistSongsBriefDto> Handle(GetPlaylistSongsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var playlistSongs = await _context.Playlists
           .Where(x => x.Id == request.Id)
           .ProjectTo<PlaylistSongsBriefDto>(_mapper.ConfigurationProvider)
           .FirstOrDefaultAsync(cancellationToken);

        if (playlistSongs is null) {
            throw new Exception("Playlist with songs doesn't exist!");
        }

        return playlistSongs;
    }
}
