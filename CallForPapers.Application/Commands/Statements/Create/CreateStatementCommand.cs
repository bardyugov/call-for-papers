using FluentResults;
using MediatR;

namespace CallForPapers.Application.Commands.Statements.Create;

public class CreateStatementCommand : IRequest<Result<CreateStatementResult>>
{
    public Guid Author { get; set; }
    
    public string Activity { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Outline { get; set; }
}