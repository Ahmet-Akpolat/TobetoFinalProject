using Application.Features.StudentStudentClasses.Commands.Create;
using Application.Features.StudentStudentClasses.Commands.Delete;
using Application.Features.StudentStudentClasses.Commands.Update;
using Application.Features.StudentStudentClasses.Queries.GetById;
using Application.Features.StudentStudentClasses.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentStudentClassesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStudentStudentClassCommand createStudentStudentClassCommand)
    {
        CreatedStudentStudentClassResponse response = await Mediator.Send(createStudentStudentClassCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStudentStudentClassCommand updateStudentStudentClassCommand)
    {
        UpdatedStudentStudentClassResponse response = await Mediator.Send(updateStudentStudentClassCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedStudentStudentClassResponse response = await Mediator.Send(new DeleteStudentStudentClassCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdStudentStudentClassResponse response = await Mediator.Send(new GetByIdStudentStudentClassQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentStudentClassQuery getListStudentStudentClassQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStudentStudentClassListItemDto> response = await Mediator.Send(getListStudentStudentClassQuery);
        return Ok(response);
    }
}