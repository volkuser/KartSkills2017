using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table(("result"))]
public class Result
{
    [Key]
    [Column("ID_Result")]
    public int ID_Result { get; set; }
    
    [Column("ID_Registration")]
    public int ID_Registration { get; set; }
    [ForeignKey("ID_Registration")]
    public Registration Registration { get; set; }
    
    [Column("ID_Event")]
    public int ID_Event { get; set; }
    [ForeignKey("ID_Event")]
    public Event Event { get; set; }
    
    [Column("BidNumber")]
    public int BidNumber { get; set; }
    [NotMapped]
    public int GenderPlace { get; set; }
    [NotMapped]
    public int AgePlace { get; set; }
    [Column("RaceTime")]
    public TimeSpan RaceTime { get; set; }
}