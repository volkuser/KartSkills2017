using App.ViewModels.SponsorMenu;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages;

[DoNotNotify]
public partial class VerificationOfPreviouslyEnteredRacersPage 
    : ReactiveUserControl<VerificationOfPreviouslyEnteredRacersPageViewModel>
{
    public VerificationOfPreviouslyEnteredRacersPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}