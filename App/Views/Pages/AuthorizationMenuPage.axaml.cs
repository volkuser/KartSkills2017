using App.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages;

[DoNotNotify]
public partial class AuthorizationMenuPage : ReactiveUserControl<AuthorizationMenuPageViewModel>
{
    public AuthorizationMenuPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}