using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("event_type")]
public class EventType
{
    [Key]
    [Column("ID_Event_type")]
    public string ID_Event_type { get; set; }
    [Column("Event_Type_Name")]
    public string? Event_Type_Name { get; set; }
}