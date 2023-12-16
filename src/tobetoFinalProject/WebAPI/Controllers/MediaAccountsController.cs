using Application.Features.MediaAccounts.Commands.Create;
using Application.Features.MediaAccounts.Commands.Delete;
using Application.Features.MediaAccounts.Commands.Update;
using Application.Features.MediaAccounts.Queries.GetById;
using Application.Features.MediaAccounts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MediaAccountsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMediaAccountCommand createMediaAccountCommand)
    {
        CreatedMediaAccountResponse response = await Mediator.Send(createMediaAccountCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMediaAccountCommand updateMediaAccountCommand)
    {
        UpdatedMediaAccountResponse response = await Mediator.Send(updateMediaAccountCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMediaAccountResponse response = await Mediator.Send(new DeleteMediaAccountCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMediaAccountResponse response = await Mediator.Send(new GetByIdMediaAccountQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMediaAccountQuery getListMediaAccountQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMediaAccountListItemDto> response = await Mediator.Send(getListMediaAccountQuery);
        return Ok(response);
    }
}