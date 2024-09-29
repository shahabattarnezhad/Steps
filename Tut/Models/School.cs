using System.ComponentModel.DataAnnotations;

namespace Tut.Models;

public class School : BaseEntity
{
    [MaxLength(150)]
    [Required(ErrorMessage = "Please fill the name")]
    public string Name { get; set; }

    [Range(0, 200, ErrorMessage = "Capacity should be between 0 to 200")]
    public int Capacity { get; set; }

    [MaxLength(700)]
    public string Address { get; set; }
}
