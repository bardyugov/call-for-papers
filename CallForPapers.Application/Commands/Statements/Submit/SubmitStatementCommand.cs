using FluentResults;
using MediatR;

namespace CallForPapers.Application.Commands.Statements.Submit;

public class SubmitStatementCommand : IRequest<Result>
{
    public Guid Id { get; set; }

    public SubmitStatementCommand(Guid id) => Id = id;
}