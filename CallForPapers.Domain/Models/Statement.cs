namespace CallForPapers.Domain.Models;

public class Statement
{
    public Guid Id { get; set; }
    
    public Guid Author { get; set; }
    
    public StatementActivity Activity { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Outline { get; set; }
    
    public DateTime CreateDate { get; set; }

    public DateTime? SubmittedTime { get; set; }
    
    public Status Status { get; set; } = Status.Unconfirmed;
}