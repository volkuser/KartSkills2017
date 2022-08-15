using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

[Table("registration_status")]
public class RegistrationStatus
{
    [Key]
    [Column("ID_Registration_Status")]
    public int ID_Registration_Status { get; set; }
    [Column("Statu_Name")]
    public string Statu_Name { get; set; }
}