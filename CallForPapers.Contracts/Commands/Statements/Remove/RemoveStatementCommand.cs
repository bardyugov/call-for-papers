using FluentResults;
using MediatR;

namespace CallForPapers.Contracts.Commands.Statements.Remove;

public class RemoveStatementCommand : IRequest<Result<string>>
{
    public Guid Id { get; set; }
}