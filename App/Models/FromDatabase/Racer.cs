using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.FromDatabase;

[Table("racer")]
public class Racer
{
    [Key]
    [Column("ID_Racer")]
    public int ID_Racer { get; set; }
    [Required]
    [Column("First_Name")]
    public string? First_Name { get; set; }
    [Required]
    [Column("Last_Name")]
    public string? Last_Name { get; set; }
    
    [Column("Gender")]
    public char Gender { get; set; }
    [Required]
    [ForeignKey("Gender")]
    public Gender? FullGender { get; set; }
    
    [Required]
    [Column("DateOfBirth")]
    public DateTime DateOfBirth { get; set; }
    
    [Column("ID_Country")]
    public string ID_Country { get; set; }
    [Required]
    [ForeignKey("ID_Country")]
    public Country? Country { get; set; }
    
    [Column("FileId")] 
    public int? FileId { get; set; }
    [ForeignKey("FileId")]
    public DbFile? File { get; set; }

    public bool CorrectDateOfBirth()
    {
        return DateOfBirth <= new DateTime(DateTime.Today.Year - 10, DateTime.Today.Month, DateTime.Today.Day);
    }
}