using FluentValidation;

namespace ViMusic.Application.Playlists.Commands.UpdatePlaylist;

public class UpdatePlaylistCommandValidator : AbstractValidator<UpdatePlaylistCommand>
{
    public UpdatePlaylistCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}
