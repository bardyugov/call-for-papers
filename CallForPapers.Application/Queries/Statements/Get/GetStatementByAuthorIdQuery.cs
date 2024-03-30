using CallForPapers.Application.Commands.Statements.Create;
using FluentResults;
using MediatR;

namespace CallForPapers.Application.Queries.Statements.Get;

public class GetStatementByAuthorIdQuery : IRequest<Result<CreateStatementResult>>
{
    public Guid AuthorId { get; set; }

    public GetStatementByAuthorIdQuery(Guid id)
    {
        AuthorId = id;
    }
}