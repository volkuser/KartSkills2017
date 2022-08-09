using App.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace App.Views.Pages;

public partial class AdministratorMenuPage : ReactiveUserControl<AdministratorMenuPageViewModel>
{
    public AdministratorMenuPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}