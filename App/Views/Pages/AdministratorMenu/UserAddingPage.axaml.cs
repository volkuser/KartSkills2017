using App.ViewModels.AdministratorMenu;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages.AdministratorMenu;

[DoNotNotify]
public partial class UserAddingPage : ReactiveUserControl<UserAddingPageViewModel>
{
    public UserAddingPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}