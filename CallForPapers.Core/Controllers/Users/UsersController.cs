using CallForPapers.Application.Queries.Statements.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CallForPapers.Core.Controllers.Users;

[ApiController]
[Route("Users")]
public class UsersController : BaseController
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator) => _mediator = mediator;
    
    [HttpGet("{id}/currentapplication")]
    public async Task<IActionResult> Get(Guid id, CancellationToken token)
    {
        var result = await _mediator.Send(new GetStatementByAuthorIdQuery(id), token);
        return ConvertToActionResult(result);
    }
}