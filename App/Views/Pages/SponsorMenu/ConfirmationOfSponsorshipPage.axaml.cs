using App.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages.SponsorMenu;

[DoNotNotify]
public partial class ConfirmationOfSponsorshipPage : ReactiveUserControl<ConfirmationOfSponsorshipPageViewModel>
{
    public ConfirmationOfSponsorshipPage()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}