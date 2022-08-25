using System.Windows.Input;
using App.Models.FromDatabase;

namespace App.Models.OnlyView;

public class ViewRacer
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string StatusName { get; set; }
    public ICommand CmdEdit { get; set; }
    
    // for filtration
    public RegistrationStatus? Status { get; set; } = new();
    public EventType? EventType { get; set; } = new();
}