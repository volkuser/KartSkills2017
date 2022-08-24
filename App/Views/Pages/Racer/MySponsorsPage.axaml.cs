using App.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages.Racer;

[DoNotNotify]
public partial class MySponsorsPage : ReactiveUserControl<MySponsorsPageViewModel>
{
    public MySponsorsPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}