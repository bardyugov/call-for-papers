using CallForPapers.Application.Commands.Statements.Create;
using FluentResults;
using MediatR;

namespace CallForPapers.Application.Queries.Statements.Get;

public class GetStatementByIdQuery : IRequest<Result<CreateStatementResult>>
{
    public Guid Id { get; set; }

    public GetStatementByIdQuery(Guid id)
    {
        Id = id;
    }
}