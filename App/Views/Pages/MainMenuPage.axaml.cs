using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using App.ViewModels;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages;

[DoNotNotify]
public partial class MainMenuPage : ReactiveUserControl<MainMenuPageViewModel>
{
    public MainMenuPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}