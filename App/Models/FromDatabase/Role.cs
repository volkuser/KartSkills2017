using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.FromDatabase;

[Table("role")]
public class Role
{
    [Key]
    [Column("ID_Role")]
    public char ID_Role { get; set; }
    [Column("Role_Name")]
    public string Role_Name { get; set; }
}