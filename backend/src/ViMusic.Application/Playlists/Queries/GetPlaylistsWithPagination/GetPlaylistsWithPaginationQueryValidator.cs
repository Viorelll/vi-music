using FluentValidation;
using ViMusic.Application.Playlists.Queries.GetPlaylistsWithPagination;

namespace ViMusic.Application.Playlists.Queries.GetPlaylistsWithPagination;

public class GetPlaylistsWithPaginationQueryValidator : AbstractValidator<GetPlaylistsWithPaginationQuery>
{
    public GetPlaylistsWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
