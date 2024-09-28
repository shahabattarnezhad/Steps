using System.ComponentModel.DataAnnotations;

namespace Tut.Models;

public class Student : BaseEntity
{
    [MaxLength(60)]
    public string FirstName { get; set; }


    [MaxLength(60)]
    public string LastName { get; set; }


    [MaxLength(11)]
    public string StudentCode { get; set; }
}
