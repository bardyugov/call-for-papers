using CallForPapers.Domain.Models;

namespace CallForPapers.Application.Commands.Statements.Create;

public class CreateStatementResult
{
    public Guid Id { get; set; }
    
    public Guid Author { get; set; }
    
    public string Activity { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Outline { get; set; }

    public CreateStatementResult (Statement statement)
    {
        Id = statement.Id;
        Author = statement.Author;
        Activity = statement.Activity.Name;
        Name = statement.Name;
        Description = statement.Description;
        Outline = statement.Outline;
    }
}