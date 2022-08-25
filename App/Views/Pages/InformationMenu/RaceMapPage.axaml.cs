using App.ViewModels.InformationMenu;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages.InformationMenu;

[DoNotNotify]
public partial class RaceMapPage : ReactiveUserControl<RaceMapPageViewModel>
{
    public RaceMapPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}