using App.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace App.Views.Pages;

public partial class RacerMenuPage : ReactiveUserControl<RacerMenuPageViewModel>
{
    public RacerMenuPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}