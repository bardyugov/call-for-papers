using CallForPapers.Application.Commands.Statements.Create;
using FluentResults;
using MediatR;

namespace CallForPapers.Application.Commands.Statements.Update;

public class UpdateStatementData
{
    public string Activity { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Outline { get; set; }
}

public class UpdateStatementCommand : IRequest<Result<CreateStatementResult>>
{
    public UpdateStatementData Data { get; set; }
    
    public Guid Id { get; set; }

    public UpdateStatementCommand(UpdateStatementData data, Guid id)
    {
        Data = data;
        Id = id;
    }
}  