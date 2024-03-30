using CallForPapers.Application.Commands.Statements.Create;
using CallForPapers.Application.Commands.Statements.Remove;
using CallForPapers.Application.Commands.Statements.Submit;
using CallForPapers.Application.Commands.Statements.Update;
using CallForPapers.Application.Queries.Statements.Get;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CallForPapers.Core.Controllers.Statements;

[ApiController]
[Route("Applications")]
public class StatementsController : BaseController
{
    private readonly IMediator _mediator;

    public StatementsController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create(CreateStatementCommand command, CancellationToken token)
    {
        var result = await _mediator.Send(command, token);
        return ConvertToActionResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(Guid id, CancellationToken token)
    {
        var result = await _mediator.Send(new RemoveStatementCommand(id), token);
        return ConvertToActionResult(result);
    }
    
    [HttpPost("{id}/submit")]
    public async Task<IActionResult> Submit(Guid id, CancellationToken token)
    {
        var result = await _mediator.Send(new SubmitStatementCommand(id), token);
        return ConvertToActionResult(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateStatementData command, Guid id, CancellationToken token)
    {
        var result = await _mediator.Send(new UpdateStatementCommand(command, id), token);
        return ConvertToActionResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken token)
    {
        var result = await _mediator.Send(new GetStatementByIdQuery(id), token);
        return ConvertToActionResult(result);
    }

    [HttpGet("SubmittedOlder")]
    public async Task<IActionResult> GetSubmittedAfter(
        [FromQuery(Name = "Time")] DateTime time,
        CancellationToken token)
    {
        var result = await _mediator.Send(new GetStatementsBySubmittedAfterQuery(time), token);
        return ConvertToActionResult(Result.Ok(result));
    }
    
    [HttpGet("UnSubmittedOlder")] 
    public async Task<IActionResult> GetUnSubmitted(
        [FromQuery(Name = "Time")] DateTime time,
        CancellationToken token
    )
    {
        var result = await _mediator.Send(new GetStatementsByUnSubmittedOlderQuery(time), token);
        return ConvertToActionResult(Result.Ok(result));

    }
}