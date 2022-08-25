using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.FromDatabase;

[Table("event")]
public class Event
{
    [Key]
    [Column("ID_Event")]
    public int ID_Event { get; set; }
    [Column("Event_Name")]
    public string Event_Name { get; set; }
    [Column("ID_EventType")]
    public string ID_EventType { get; set; }
    
    [Column("ID_Race")]
    public int ID_Race { get; set; }
    [ForeignKey("ID_Race")]
    public Race Race { get; set; }
    
    [Column("StartDateTime")]
    public DateTime StartDateTime { get; set; }
    [Column("Cost")]
    public int Cost { get; set; }
    [Column("MaxParticipants")]
    public int MaxParticipants { get; set; }
}