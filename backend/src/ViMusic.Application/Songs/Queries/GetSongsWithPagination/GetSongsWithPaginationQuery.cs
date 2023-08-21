using AutoMapper;
using AutoMapper.QueryableExtensions;
using ViMusic.Application.Common.Interfaces;
using ViMusic.Application.Common.Mappings;
using ViMusic.Application.Common.Models;
using MediatR;

namespace ViMusic.Application.Songs.Queries.GetSongsWithPagination;

public record GetSongsWithPaginationQuery : IRequest<PaginatedList<SongBriefDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetSongsWithPaginationQueryHandler : IRequestHandler<GetSongsWithPaginationQuery, PaginatedList<SongBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSongsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<SongBriefDto>> Handle(GetSongsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Songs
            .OrderBy(x => x.Title)
            .ProjectTo<SongBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
