using CallForPapers.Application.Commands.Statements.Create;
using CallForPapers.Application.Commands.Statements.Remove;
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

    [HttpPut("{id}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        var result = await _mediator.Send(new RemoveStatementCommand(id));
        return ConvertToActionResult(result);
    }
}