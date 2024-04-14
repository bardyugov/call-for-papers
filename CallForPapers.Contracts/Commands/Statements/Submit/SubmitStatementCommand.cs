using FluentResults;
using MediatR;

namespace CallForPapers.Contracts.Commands.Statements.Submit;

public class SubmitStatementCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}