using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Input;
using ReactiveUI;

namespace App.Models;

[Table("charity")]
public class Charity
{
    [Key]
    [Column("ID_Сharity")]
    public int ID_Сharity { get; set; }
    [Column("Charity_Name")]
    public string Charity_Name { get; set; }
    [Column("Charity_Description")]
    public string Charity_Description { get; set; }
    
    [Column("Charity_Logo")]
    public string Charity_Logo { get; set; }
    [NotMapped]
    public string FullCharity_Logo { get; set; }
    
    [Column("FileId")] 
    public int? FileId { get; set; }
    [ForeignKey("FileId")]
    public DbFile? File { get; set; }

    [NotMapped]
    public string? FileName { get; set; }

    [NotMapped] 
    public ICommand CmdEdit { get; set; } = ReactiveCommand.Create(() => { });
}