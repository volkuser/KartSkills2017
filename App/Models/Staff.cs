using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("Staff")]
public class Staff
{
    [Key]
    [Column("Staffid")]
    public int Staffid { get; set; }
    [Column("First_name")]
    public string First_name { get; set; }
    [Column("LastName")]
    public string LastName { get; set; }
    [Column("DateOfBirth")]
    public DateTime DateOfBirth { get; set; }
    [Column("Gender")]
    public string Gender { get; set; }
    
    [Column("Positionid")]
    public int Positionid { get; set; }
    [ForeignKey("Positionid")]
    public Position Position { get; set; }
    
    [Column("Email")]
    public string Email { get; set; }
    [Column("Comments")]
    public string Comments { get; set; }
}