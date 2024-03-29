using System.Linq;
using System.Windows.Input;
using App.Models;
using App.Models.FromDatabase;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class AuthorizationMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "authorizationMenu";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ICommand OnClickBtnCancel { get; set; }
    private ICommand OnClickBtnLogin { get; set; }

    private string? Email { get; set; } 
    private string? Password { get; set; } 

    private User? User { get; set; } = new();

    public AuthorizationMenuPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        OnClickBtnCancel = ReactiveCommand.Create(container.Back);
        OnClickBtnLogin = ReactiveCommand.Create(() =>
        {
            if (User != null) UserLogin(Email, Password, Db, container, User);
        });
    }

    private void UserLogin(string? email, string? password, ApplicationContext db, IPageNavigation container, User? user)
    {
        /*for testing*/
        //container.OpnAdministratorMenuPage();
        //container.OpnCoordinatorMenuPage();
        /*for testing*/
        if (db.Users != null) user = db.Users.FirstOrDefault(x => x != null && x.Email != null 
                                                                            && x.Email.Equals(email));
        if (user == null) return;
        if (user.Password!.Equals(password))
        {
            switch (user.ID_Role)
            {
                // administrator
                case 'A':
                    container.OpnAdministratorMenuPage();
                    break;
                // coordinator
                case 'C':
                    container.OpnCoordinatorMenuPage();
                    break;
                // racer
                case 'R':
                    container.OpnRacerMenuPage(user);
                    break;
            }
        }
        else
        {
            var messageBox = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Ошибка входа", "Неверный пароль");
            messageBox.Show();
        }
    }
}