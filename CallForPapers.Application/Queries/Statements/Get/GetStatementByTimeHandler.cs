using CallForPapers.Application.Extensions;
using CallForPapers.Contracts.Queries.Statements.Get;
using CallForPapers.Contracts.Repositories;
using CallForPapers.Domain.Models;
using FluentResults;
using MediatR;

namespace CallForPapers.Application.Queries.Statements.Get;

public class GetStatementByTimeHandler(IStatementRepository repository) : IRequestHandler<GetStatementByTimeQuery, Result<List<GetStatementResultByQuery>>>
{
    public async Task<Result<List<GetStatementResultByQuery>>> Handle(GetStatementByTimeQuery request, CancellationToken cancellationToken)
    {
        var status = request.UnSubmittedOlder.IsMin() ? Status.Confirmed : Status.Unconfirmed;
        var time = status == Status.Confirmed ? request.SubmittedAfter : request.UnSubmittedOlder;
        var statements = await repository.FindByStatus(status, cancellationToken);
       
        var result = statements
            .Where(v =>
                status == Status.Confirmed
                ? v.SubmittedTime > time
                : time < v.CreateDate)
            .Select(v => 
                new GetStatementResultByQuery {
                    Id = v.Id,
                    Author = v.Author,
                    Name = v.Name,
                    Description = v.Description,
                    Outline = v.Outline,
                    Activity = v.Activity.Name
                })
            .ToList();
        
        return Result.Ok(result);
        
    }
}