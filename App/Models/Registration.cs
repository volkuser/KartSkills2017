using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("registration")]
public class Registration
{
    [Key]
    [Column("ID_Registration")]
    public int ID_Registration { get; set; }
    
    [Column("ID_Racer")]
    public int ID_Racer { get; set; }
    [ForeignKey("ID_Racer")]
    public Racer Racer { get; set; }
    
    [Column("Registration_Date")]
    public DateTime Registration_Date { get; set; }

    [Column("ID_Registration_Status")] 
    public int ID_Registration_Status { get; set; }
    [ForeignKey("ID_Registration_Status")]
    public RegistrationStatus RegistrationStatus { get; set; }
    
    [Column("Cost")]
    public int Cost { get; set; }
    
    [Column("ID_Charity")]
    public int ID_Charity { get; set; }
    [ForeignKey("ID_Charity")]
    public Charity Charity { get; set; }
    
    [Column("SponsorshipTarget")]
    public int SponsorshipTarget { get; set; }
}