using System.ComponentModel.DataAnnotations;

namespace CallForPapers.Domain.Models;

public class Application
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public Guid Author { get; set; }
    
    [Required]
    public TypeActivity Activity { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    [Required]
    public string Outline { get; set; }
}