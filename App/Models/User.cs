using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("user")]
public class User
{
    [Column("Email")]
    public string Email { get; set; }
    [Column("Password")]
    public string Password { get; set; }
    [Column("First_Name")]
    public string First_Name { get; set; }
    [Column("Last_Name")]
    public string Last_Name { get; set; }
    [Key]
    [Column("ID_Role")]
    public char ID_Role { get; set; }
}