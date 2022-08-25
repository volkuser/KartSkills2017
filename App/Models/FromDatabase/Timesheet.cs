using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.FromDatabase;

[Table("Timesheet")]
public class Timesheet
{
    [Key]
    [Column("Timesheetid")]
    public int Timesheetid { get; set; }
    
    [Column("Staffid")]
    public int Staffid { get; set; }
    [ForeignKey("Staffid")]
    public Staff Staff { get; set; }
    
    [Column("StartDateTime")]
    public DateTime StartDateTime { get; set; }
    [Column("EndDateTime")]
    public DateTime EndDateTime { get; set; }
    [Column("PayAmount")]
    public decimal PayAmount { get; set; }
}