using App.ViewModels.CoordinatorMenu;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages.CoordinatorMenu;

[DoNotNotify]
public partial class ControlOfUserPage : ReactiveUserControl<ControlOfUserPageViewModel>
{
    public ControlOfUserPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}