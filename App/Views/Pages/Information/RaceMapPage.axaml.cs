using App.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages.Information;

[DoNotNotify]
public partial class RaceMapPage : ReactiveUserControl<RaceMapPageViewModel>
{
    public RaceMapPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}