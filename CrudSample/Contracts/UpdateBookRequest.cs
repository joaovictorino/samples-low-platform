using System.ComponentModel.DataAnnotations;

namespace CrudSample.Contracts;

public class UpdateBookRequest
{
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Author { get; set; } = string.Empty;

    [Range(1450, 2100)]
    public int YearPublished { get; set; }
}
