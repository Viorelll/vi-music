using AutoMapper;
using AutoMapper.QueryableExtensions;
using ViMusic.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ViMusic.Application.Playlists.Queries.GetPlaylistsWithPagination;

namespace ViMusic.Application.Playlists.Queries.GetPlaylistSongsWithPagination;

public record GetPlaylistSongsWithPaginationQuery : IRequest<PlaylistBriefDto>
{
    public int Id { get; set; }
}

public class GetPlaylistSongsWithPaginationQueryHandler : IRequestHandler<GetPlaylistSongsWithPaginationQuery, PlaylistBriefDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPlaylistSongsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PlaylistBriefDto> Handle(GetPlaylistSongsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var playlist = await _context.Playlists
            .Where(x => x.Id == request.Id)
            .ProjectTo<PlaylistBriefDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (playlist is null) {
            throw new Exception("Playlist doesn't exist!");
        }

        return playlist;
    }
}
