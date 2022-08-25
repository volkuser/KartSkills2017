using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.FromDatabase;

[Table("gender")]
public class Gender
{
    [Key]
    [Column("ID_Gender")]
    public char ID_Gender { get; set; }
    [Column("Gender_Name")]
    public string? Gender_Name { get; set; }
}