using System.Collections.ObjectModel;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class AuthorizationMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "authorizationMenu";
    public IScreen HostScreen { get; }

    private ApplicationContext Db { get; set; }
    
    public bool VisibleBtnBack { get; } = false;
    
    private ICommand OnClickBtnCancel { get; set; }
    private ICommand OnClickBtnLogin { get; set; }
    
    private string Login { get; set; }
    private string Password { get; set; }

    public AuthorizationMenuPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        OnClickBtnCancel = ReactiveCommand.Create(() => container.Back());
        OnClickBtnLogin = ReactiveCommand.Create(() => UserLogin(Login, Password, Db, container));
    }

    private void UserLogin(string login, string password, ApplicationContext db, IPageNavigation container)
    {
        ObservableCollection<User> users = new(db.Users);
        
    }
}