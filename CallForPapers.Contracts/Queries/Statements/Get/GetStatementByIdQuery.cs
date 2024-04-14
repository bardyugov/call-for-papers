using FluentResults;
using MediatR;

namespace CallForPapers.Contracts.Queries.Statements.Get;

public class GetStatementByIdQuery : IRequest<Result<GetStatementResultByQuery>>
{
    public Guid Id { get; set; } 
}