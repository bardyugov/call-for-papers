namespace CallForPapers.Infrastructure.Requests;

public class UpdateStatementRequest
{
    public Guid Author { get; set; }
    
    public string Activity { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Outline { get; set; }
}