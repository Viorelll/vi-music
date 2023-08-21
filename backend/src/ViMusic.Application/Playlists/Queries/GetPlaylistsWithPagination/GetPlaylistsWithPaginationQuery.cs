using AutoMapper;
using AutoMapper.QueryableExtensions;
using ViMusic.Application.Common.Interfaces;
using ViMusic.Application.Common.Mappings;
using ViMusic.Application.Common.Models;
using MediatR;
using ViMusic.Application.Songs.Queries.GetSongsWithPagination;

namespace ViMusic.Application.Playlists.Queries.GetPlaylistsWithPagination;

public record GetPlaylistsWithPaginationQuery : IRequest<PaginatedList<PlaylistBriefDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetPlaylistsWithPaginationQueryHandler : IRequestHandler<GetPlaylistsWithPaginationQuery, PaginatedList<PlaylistBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPlaylistsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PlaylistBriefDto>> Handle(GetPlaylistsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Playlists
            .OrderBy(x => x.Name)
            .ProjectTo<PlaylistBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
