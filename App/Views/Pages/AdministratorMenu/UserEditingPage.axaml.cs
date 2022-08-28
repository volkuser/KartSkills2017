using App.ViewModels.AdministratorMenu;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages.AdministratorMenu;

[DoNotNotify]
public partial class UserEditingPage : ReactiveUserControl<UserEditingPageViewModel>
{
    public UserEditingPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}