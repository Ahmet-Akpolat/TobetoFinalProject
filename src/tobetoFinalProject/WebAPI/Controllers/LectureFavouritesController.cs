using Application.Features.LectureFavourites.Commands.Create;
using Application.Features.LectureFavourites.Commands.Delete;
using Application.Features.LectureFavourites.Commands.Update;
using Application.Features.LectureFavourites.Queries.GetById;
using Application.Features.LectureFavourites.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LectureFavouritesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLectureFavouriteCommand createLectureFavouriteCommand)
    {
        CreatedLectureFavouriteResponse response = await Mediator.Send(createLectureFavouriteCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLectureFavouriteCommand updateLectureFavouriteCommand)
    {
        UpdatedLectureFavouriteResponse response = await Mediator.Send(updateLectureFavouriteCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedLectureFavouriteResponse response = await Mediator.Send(new DeleteLectureFavouriteCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdLectureFavouriteResponse response = await Mediator.Send(new GetByIdLectureFavouriteQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLectureFavouriteQuery getListLectureFavouriteQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLectureFavouriteListItemDto> response = await Mediator.Send(getListLectureFavouriteQuery);
        return Ok(response);
    }
}