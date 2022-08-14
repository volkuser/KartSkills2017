using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("user")]
public class User
{
    [Key]
    [Required]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
    [Column("Email")]
    public string Email { get; set; }
    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{6,}$")]
    [Column("Password")]
    public string Password { get; set; }
    [NotMapped]
    public string RepeatPassword { get; set; }
    [Required]
    [Column("First_Name")]
    public string First_Name { get; set; }
    [Required]
    [Column("Last_Name")]
    public string Last_Name { get; set; }
    
    [Column("ID_Role")]
    public char ID_Role { get; set; }
    [ForeignKey("ID_Role")]
    public Role Role { get; set; }

    public bool PasswordCompare()
    {
        return RepeatPassword.Equals(Password);
    }
}