namespace CallForPapers.Contracts.Commands.Statements.Update;

public class UpdateStatementResult
{
    public Guid Id { get; set; }

    public Guid Author { get; set; }

    public string Activity { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Outline { get; set; }
}