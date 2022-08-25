using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.FromDatabase;

[Table("race")]
public class Race
{
    [Key]
    [Column("ID_Race")]
    public int ID_Race { get; set; }
    [Column("Race_Name")]
    public string Race_Name { get; set; }
    [Column("Sity")]
    public string Sity { get; set; }
    
    [Column("ID_Country")]
    public string? ID_Country { get; set; }
    [ForeignKey("ID_Country")]
    public Country Country { get; set; }
    
    [Column("Year_Held")]
    public int Year_Held { get; set; }
}