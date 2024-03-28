
namespace CallForPapers.Domain.Models;

public class Statement
{
    public Guid Id { get; set; }
    
    public Guid Author { get; set; }
    
    public TypeActivity Activity { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Outline { get; set; }
    
    public Status Status { get; set; } = Status.Unconfirmed;
}