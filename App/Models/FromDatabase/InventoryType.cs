using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("InventoryType")]
public class InventoryType
{
    [Key]
    [Column("InventoryTypeId")]
    public int InventoryTypeId { get; set; }
    [Column("TypeName")]
    public string TypeName { get; set; }
}