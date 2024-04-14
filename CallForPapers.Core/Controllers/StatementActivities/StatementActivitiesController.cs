using CallForPapers.Application.Queries.StatementActivities.Get;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CallForPapers.Core.Controllers.StatementActivities;

[ApiController]
[Route("/activities")]
public class StatementActivitiesController : BaseController
{
    private readonly IMediator _mediator;

    public StatementActivitiesController(IMediator mediator) => _mediator = mediator; 
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetStatementActivitiesQuery());
        return ConvertToActionResult(Result.Ok(result));
    }
}