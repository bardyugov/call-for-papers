using CallForPapers.Contracts.Queries.StatementActivities.Get;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CallForPapers.Infrastructure.Controllers.StatementActivities;

[Route("/activities")]
public class StatementActivitiesController(IMediator mediator) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken token)
    {
        var result = await mediator.Send(new GetStatementActivitiesQuery(), token);
        return ConvertToActionResult(result);
    }
}