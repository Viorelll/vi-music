using FluentValidation;

namespace ViMusic.Application.Playlists.Commands.AddSongToPlaylist;

public class CreatePlaylistCommandValidator : AbstractValidator<AddSongToPlaylistCommand>
{
    public CreatePlaylistCommandValidator()
    {
        RuleFor(x => x.PlaylistId)
            .GreaterThanOrEqualTo(1).WithMessage("Playlist Id at least greater than or equal to 1.");

        RuleFor(x => x.SongId)
            .GreaterThanOrEqualTo(1).WithMessage("Song Id at least greater than or equal to 1.");
    }
}
