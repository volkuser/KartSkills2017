using App.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages.Information;

[DoNotNotify]
public partial class RacerCardWindow : ReactiveWindow<RacerCardWindowViewModel>
{
    public RacerCardWindow()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}