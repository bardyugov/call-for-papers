using FluentResults;
using MediatR;

namespace CallForPapers.Application.Commands.Statements.Remove;

public class RemoveStatementCommand : IRequest<Result<string>>
{
    public Guid Id { get; set; }

    public RemoveStatementCommand(Guid id) => Id = id;
}