using App.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace App.Views.Pages;

public partial class AuthorizationMenuPage : ReactiveUserControl<AuthorizationMenuPageViewModel>
{
    public AuthorizationMenuPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}