using CallForPapers.Contracts.Queries.Statements.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CallForPapers.Infrastructure.Controllers.Users;

[Route("users")]
public class UsersController(IMediator mediator) : BaseController
{
    [HttpGet("{id}/currentapplication")]
    public async Task<IActionResult> Get(Guid id, CancellationToken token)
    {
        var result = await mediator.Send(new GetStatementByAuthorIdQuery { AuthorId = id }, token);
        return ConvertToActionResult(result);
    }
}