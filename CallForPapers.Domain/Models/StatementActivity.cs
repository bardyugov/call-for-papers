namespace CallForPapers.Domain.Models;

public class StatementActivity
{
    public Guid Id { get; }

    public string Name { get; }

    public string Description { get; }
    
    public List<Statement> Statements { get; }

    public StatementActivity(Guid id, string name, string description, List<Statement> statements)
    {
        Id = id;
        Name = name;
        Description = description;
        Statements = statements;
    }
    
    private StatementActivity(){}
}