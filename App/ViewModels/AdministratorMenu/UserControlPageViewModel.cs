using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using App.Models;
using App.Models.FromDatabase;
using App.Models.OnlyView;
using ReactiveUI;
using Splat;

namespace App.ViewModels.AdministratorMenu;

public class UserControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "userControl";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }

    private ICommand OnClickBtnAddNew { get; set; }
    private ICommand? OnClickBtnUpdate { get; set; }  
    
    private ObservableCollection<Role>? Roles { get; set; }
    private Role? Role { get; set; }
    
    private string? SearchQuery { get; set; }
    
    private int UserCount { get; set; }
    
    private ObservableCollection<ViewUser> ViewUsers { get; set; }

    public UserControlPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        Roles = new ObservableCollection<Role>(Db.Roles!);

        ViewUsers = GetListWithUsers(Db, container);
        UserCount = ViewUsers.Count;

        OnClickBtnAddNew = ReactiveCommand.Create(container.OpnUserAddingPage);
        OnClickBtnUpdate = ReactiveCommand.Create(() =>
        {
            ViewUsers = GetListWithUsers(Db, container);
            Update(Role, SearchQuery);
        });
    }

    private ObservableCollection<ViewUser> GetListWithUsers(ApplicationContext db, IPageNavigation container)
    {
        ObservableCollection<ViewUser> viewUsers = new ();

        List<User> users = new(db.Users!);
        foreach (var user in users)
        {
            ViewUser additionUser = new ()
            {
                FirstName = user.First_Name,
                LastName = user.Last_Name,
                Email = user.Email
            };
            var currentRole = db.Roles!.FirstOrDefault(x => x.ID_Role.Equals(user.ID_Role));
            additionUser.Role = currentRole!.Role_Name;
            additionUser.CmdEdit = ReactiveCommand.Create(() => container.OpnUserEditingPage(user));
            
            viewUsers.Add(additionUser);
        }
        
        return viewUsers;
    }

    private void Update(Role? selectedRole, string? searchQuery)
    {
        var viewUsers = ViewUsers.ToList();
        foreach (var user in viewUsers)
        {
            if (Role != null && searchQuery != null)
                if (user.Role!.Equals(selectedRole!.Role_Name) && (user.FirstName!.Contains(searchQuery) 
                                                                   || user.LastName!.Contains(searchQuery) 
                                                                   || user.Email!.Contains(searchQuery) 
                                                                   || user.Role!.Contains(searchQuery))) continue;
            if (Role != null)
                if (user.Role!.Equals(selectedRole!.Role_Name)) continue;
            if (searchQuery != null)
                if (user.FirstName!.Contains(searchQuery) || user.LastName!.Contains(searchQuery)
                    || user.Email!.Contains(searchQuery) || user.Role!.Contains(searchQuery)) continue;
            ViewUsers.Remove(user);
        }
        
        UserCount = ViewUsers.Count;
    }
}