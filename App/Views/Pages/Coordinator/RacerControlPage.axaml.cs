using App.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages.Coordinator;

[DoNotNotify]
public partial class RacerControlPage : ReactiveUserControl<RacerControlPageViewModel>
{
    public RacerControlPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}