using System.Collections.ObjectModel;
using System.Windows.Input;
using App.Models;
using App.Models.FromDatabase;
using ReactiveUI;
using Splat;

namespace App.ViewModels.AdministratorMenu;

public class UserAddingPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "userAdding";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public ObservableCollection<Role>? Roles { get; set; }
    public Role? Role { get; set; }
    public string? Password { get; set; }
    public string? RepeatPassword { get; set; }
    
    public ICommand? OnClickBtnSave { get; set; }
    public ICommand? OnClickBtnCancel { get; set; }

    public UserAddingPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        Roles = new ObservableCollection<Role>(Db.Roles!);
        
        OnClickBtnCancel = ReactiveCommand.Create(container.Back);
        OnClickBtnSave = ReactiveCommand.Create(() => Save(Db, Email!, FirstName!, LastName!, Role!,
            Password!, RepeatPassword!));
    }

    private void Save(ApplicationContext db, string email, string firstName, string lastName, Role role,
        string password, string repeatPassword)
    {
        var newUser = new User()
        {
            Email = email,
            First_Name = firstName,
            Last_Name = lastName,
            Role = role,
            Password = password,
            RepeatPassword = repeatPassword
        };
        if (ApplicationContext.IsValid(newUser) && newUser.PasswordCompare())
        {
            db.Users?.Add(newUser);
            db.SaveChanges();
        }
    }
}