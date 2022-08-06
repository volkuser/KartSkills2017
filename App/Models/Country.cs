using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("country")]
public class Country
{
    [Key]
    [Column("ID_Country")]
    public string ID_Country { get; set; }
    [Column("Country_Name")]
    public string Country_Name { get; set; }
    [Column("Country_Flag")]
    public string Country_Flag { get; set; }
}