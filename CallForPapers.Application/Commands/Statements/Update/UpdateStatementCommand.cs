using CallForPapers.Application.Commands.Statements.Create;
using FluentResults;
using MediatR;

namespace CallForPapers.Application.Commands.Statements.Update;

public class UpdateStatementCommand : IRequest<Result<CreateStatementResult>>
{
    public Guid Id { get; set; }
    
    public string Activity { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Outline { get; set; }

    public void SetId(Guid id) => Id = id;

}  