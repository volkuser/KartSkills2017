using App.ViewModels.InformationMenu;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages.InformationMenu;

[DoNotNotify]
public partial class DetailedInformationPage : ReactiveUserControl<DetailedInformationPageViewModel>
{
    public DetailedInformationPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}