using App.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages;

[DoNotNotify]
public partial class SponsorOfRacersPage : ReactiveUserControl<SponsorOfRacersPageViewModel>
{
    public SponsorOfRacersPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}