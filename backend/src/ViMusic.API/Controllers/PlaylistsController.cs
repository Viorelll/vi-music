using ViMusic.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using ViMusic.Application.Playlists.Commands.CreatePlaylist;
using ViMusic.Application.Playlists.Commands.DeletePlaylist;
using ViMusic.Application.Playlists.Commands.UpdatePlaylist;
using ViMusic.Application.Playlists.Queries.GetPlaylistsWithPagination;
using ViMusic.Application.Playlists.Queries.GetPlaylistSongsWithPagination;
using ViMusic.Application.Playlists.Commands.AddSongToPlaylist;

namespace ViMusic.API.Controllers;

public class PlaylistsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<PlaylistBriefDto>>> GetPlaylistsWithPagination([FromQuery] GetPlaylistsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("get-songs")]
    public async Task<ActionResult<PlaylistBriefDto>> GetPlaylistSongsWithPagination([FromQuery] GetPlaylistSongsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreatePlaylistCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPost("add-song-to-playlist")]
    public async Task<ActionResult<int>> AddSongToPlaylist(AddSongToPlaylistCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdatePlaylistCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeletePlaylistCommand(id));

        return NoContent();
    }
}
