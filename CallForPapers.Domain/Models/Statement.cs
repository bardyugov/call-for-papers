using System.ComponentModel.DataAnnotations;

namespace CallForPapers.Domain.Models;

public class Statement
{
    public Guid Id { get; set; }
    
    public Guid Author { get; set; }
    
    [Required]
    public StatementActivity Activity { get; set; }
    
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string Outline { get; set; }
    
    public DateTime CreateDate { get; set; }

    public DateTime? SubmittedTime { get; set; }
    
    public Status Status { get; set; } = Status.Unconfirmed;
}