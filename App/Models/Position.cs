using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("Position")]
public class Position
{
    [Key]
    [Column("Positionid")]
    public int Positionid { get; set; }
    [Column("PositionName")]
    public string PositionName { get; set; }
    [Column("PositionDescription")]
    public string PositionDescription { get; set; }
    [Column("PayPeriod")]
    public string PayPeriod { get; set; }
    [Column("PayRate")]
    public decimal PayRate { get; set; }
}