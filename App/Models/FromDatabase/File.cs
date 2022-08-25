using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.FromDatabase;

[Table("File")]
public class DbFile
{
    [Key]
    [Column("FileId")]
    public int FileId { get; set; }
    [Column("FileName")]
    public string FileName { get; set; }
    [Column("File")]
    public byte[] FileItself { get; set; }
}