using FluentResults;
using MediatR;

namespace CallForPapers.Contracts.Queries.Statements.Get;

public class GetStatementByAuthorIdQuery : IRequest<Result<GetStatementResultByQuery>>
{
    public Guid AuthorId { get; set; }
}