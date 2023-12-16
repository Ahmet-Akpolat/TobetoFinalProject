using Application.Features.StudentMediaAccounts.Commands.Create;
using Application.Features.StudentMediaAccounts.Commands.Delete;
using Application.Features.StudentMediaAccounts.Commands.Update;
using Application.Features.StudentMediaAccounts.Queries.GetById;
using Application.Features.StudentMediaAccounts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentMediaAccountsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStudentMediaAccountCommand createStudentMediaAccountCommand)
    {
        CreatedStudentMediaAccountResponse response = await Mediator.Send(createStudentMediaAccountCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStudentMediaAccountCommand updateStudentMediaAccountCommand)
    {
        UpdatedStudentMediaAccountResponse response = await Mediator.Send(updateStudentMediaAccountCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedStudentMediaAccountResponse response = await Mediator.Send(new DeleteStudentMediaAccountCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdStudentMediaAccountResponse response = await Mediator.Send(new GetByIdStudentMediaAccountQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentMediaAccountQuery getListStudentMediaAccountQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStudentMediaAccountListItemDto> response = await Mediator.Send(getListStudentMediaAccountQuery);
        return Ok(response);
    }
}