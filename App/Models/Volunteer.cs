using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("volunteer")]
public class Volunteer
{
    [Key]
    [Column("ID_Volunteer")]
    public string ID_Volunteer { get; set; }
    [Column("First_Name")]
    public string First_Name { get; set; }
    [Column("Last_Name")]
    public string Last_Name { get; set; }
    
    [Column("ID_Country")]
    public string ID_Country { get; set; }
    [ForeignKey("ID_Country")]
    public Country Country { get; set; }
    
    [Column("Gender_ID")]
    public char Gender_ID { get; set; }
    [ForeignKey("Gender_ID")]
    public Gender Gender { get; set; }
}