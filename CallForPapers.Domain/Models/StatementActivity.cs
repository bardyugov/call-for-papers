namespace CallForPapers.Domain.Models;

public class StatementActivity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public List<Statement> Statements { get; set; }

    public StatementActivity(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }
}