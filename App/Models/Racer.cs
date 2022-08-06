using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("racer")]
public class Racer
{
    [Key]
    [Column("ID_Racer")]
    public int ID_Racer { get; set; }
    [Column("First_Name")]
    public string First_Name { get; set; }
    [Column("Last_Name")]
    public string Last_Name { get; set; }
    
    [Column("Gender")]
    public char Gender { get; set; }
    [ForeignKey("Gender")]
    public Gender FullGender { get; set; }
    
    [Column("DateOfBirth")]
    public DateTime DateOfBirth { get; set; }
    
    [Column("ID_Country")]
    public string ID_Country { get; set; }
    [ForeignKey("ID_Country")]
    public Country Country { get; set; }
}