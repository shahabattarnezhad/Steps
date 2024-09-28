using System.ComponentModel.DataAnnotations;

namespace Tut.Models;

public class School : BaseEntity
{
    [MaxLength(150)]
    public string Name { get; set; }

    public int Capacity { get; set; }

    [MaxLength(700)]
    public string Address { get; set; }
}
