using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("sponsorship")]
public class Sponsorship
{
    [Key]
    [Column("ID_Sponsorship")]
    public int ID_Sponsorship { get; set; }
    [Column("SponsorName")]
    public string SponsorName { get; set; }
    [Column("Amount")]
    public decimal Amount { get; set; }
}