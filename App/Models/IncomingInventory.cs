using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table(("IncomingInventory"))]
public class IncomingInventory
{
    [Key]
    [Column("IncomingInventoryId")]
    public int IncomingInventoryId { get; set; }
    
    /*[Column("ID_Racer")]
    public int ID_Racer { get; set; }
    [ForeignKey("ID_Racer")]
    public Racer Racer { get; set; }*/
    
    [Column("Bracelet")]
    public int Bracelet { get; set; }
    [Column("Helmet")]
    public int Helmet { get; set; }
    [Column("Equipment")]
    public int Equipment { get; set; }
}