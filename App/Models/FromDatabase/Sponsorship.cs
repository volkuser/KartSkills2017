using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.FromDatabase;

[Table("sponsorship")]
public class Sponsorship
{
    [Key]
    [Column("ID_Sponsorship")]
    public int ID_Sponsorship { get; set; }
    [Column("SponsorName")]
    public string? SponsorName { get; set; }
    [Column("Amount")]
    public decimal Amount { get; set; }
    
    [Column("ID_Racer")]
    public int ID_Racer { get; set; }
    [ForeignKey("ID_Racer")]
    public Racer? Racer { get; set; }
}