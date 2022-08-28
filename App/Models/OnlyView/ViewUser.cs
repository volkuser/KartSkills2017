using System.Windows.Input;

namespace App.Models.OnlyView;

public class ViewUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
    public ICommand? CmdEdit { get; set; }
}