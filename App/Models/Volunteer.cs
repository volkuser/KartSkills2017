using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration.Attributes;

namespace App.Models;

[Table("volunteer")]
public class Volunteer
{
    [Key]
    [Column("ID_Volunteer")]
    [Name("VolunteerId")]
    public string ID_Volunteer { get; set; }
    [Column("First_Name")]
    [Name("FirstName")]
    public string First_Name { get; set; }
    [Column("Last_Name")]
    [Name("LastName")]
    public string Last_Name { get; set; }
    
    [Column("ID_Country")]
    [Name("CountryCode")]
    public string ID_Country { get; set; }
    [ForeignKey("ID_Country")]
    public Country Country { get; set; }
    
    [Column("Gender_ID")]
    [Name("Gender")]
    public char Gender_ID { get; set; }
    [ForeignKey("Gender_ID")]
    public Gender Gender { get; set; }
}