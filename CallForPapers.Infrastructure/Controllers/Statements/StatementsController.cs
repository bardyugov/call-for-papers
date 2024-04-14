using CallForPapers.Contracts.Commands.Statements.Create;
using CallForPapers.Contracts.Commands.Statements.Remove;
using CallForPapers.Contracts.Commands.Statements.Submit;
using CallForPapers.Contracts.Commands.Statements.Update;
using CallForPapers.Contracts.Queries.Statements.Get;
using CallForPapers.Infrastructure.Requests;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CallForPapers.Infrastructure.Controllers.Statements;

[Route("applications")]
public class StatementsController(IMediator mediator) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateStatementCommand command, CancellationToken token)
    {
        var result = await mediator.Send(command, token);
        return ConvertToActionResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(Guid id, CancellationToken token)
    {
        var result = await mediator.Send(new RemoveStatementCommand { Id = id }, token);
        return ConvertToActionResult(result);
    }
    
    [HttpPost("{id}/submit")]
    public async Task<IActionResult> Submit(Guid id, CancellationToken token)
    {
        var result = await mediator.Send(new SubmitStatementCommand { Id = id }, token);
        return ConvertToActionResult(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateStatementRequest request, CancellationToken token)
    {
        var command = new UpdateStatementCommand
        {
            Id = id,
            Author = request.Author,
            Name = request.Name,
            Description = request.Description,
            Outline = request.Outline,
            Activity = request.Activity
        };
        var result = await mediator.Send(command, token);
        return ConvertToActionResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken token)
    {
        var result = await mediator.Send(new GetStatementByIdQuery { Id = id }, token);
        return ConvertToActionResult(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetByQueryTime(
        [FromQuery(Name = "submittedAfter")] DateTime submittedAfter,
        [FromQuery(Name = "unSubmittedOlder")] DateTime unSubmittedOlder,
        CancellationToken token
        )
    {
        var command = new GetStatementByTimeQuery
        {
            SubmittedAfter = submittedAfter,
            UnSubmittedOlder = unSubmittedOlder
        };
        var result = await mediator.Send(command, token);
        return ConvertToActionResult(result);
    }
    
}