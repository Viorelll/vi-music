using ViMusic.Application.Common.Models;
using ViMusic.Application.Songs.Commands.CreateSong;
using ViMusic.Application.Songs.Commands.DeleteSong;
using ViMusic.Application.Songs.Commands.UpdateSong;
using ViMusic.Application.Songs.Queries.GetSongsWithPagination;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ViMusic.API.Controllers;

public class SongsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<SongBriefDto>>> GetSongsWithPagination([FromQuery] GetSongsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateSongCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdateSongCommand command)
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
        await Mediator.Send(new DeleteSongCommand(id));

        return NoContent();
    }
}
