using App.ViewModels.CoordinatorMenu;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages.CoordinatorMenu;

[DoNotNotify]
public partial class EditingOfProfilePage : ReactiveUserControl<EditingOfProfilePageViewModel>
{
    public EditingOfProfilePage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}