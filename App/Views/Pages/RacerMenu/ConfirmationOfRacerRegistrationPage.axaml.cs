using App.ViewModels.RacerMenu;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages.RacerMenu;

[DoNotNotify]
public partial class ConfirmationOfRacerRegistrationPage 
    : ReactiveUserControl<ConfirmationOfRacerRegistrationPageViewModel>
{
    public ConfirmationOfRacerRegistrationPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}