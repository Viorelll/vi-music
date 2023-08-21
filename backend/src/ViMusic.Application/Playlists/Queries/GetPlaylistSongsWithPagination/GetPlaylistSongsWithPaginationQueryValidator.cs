using FluentValidation;
using ViMusic.Application.Playlists.Queries.GetPlaylistsWithPagination;

namespace ViMusic.Application.Playlists.Queries.GetPlaylistSongsWithPagination;

public class GetPlaylistSongsWithPaginationQueryValidator : AbstractValidator<GetPlaylistSongsWithPaginationQuery>
{
    public GetPlaylistSongsWithPaginationQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThanOrEqualTo(1).WithMessage("Playlist at least greater than or equal to 1.");
    }
}
