using App.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages;

[DoNotNotify]
public partial class RacerRegistrationPage : ReactiveUserControl<RacerRegistrationPageViewModel>
{
    public RacerRegistrationPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}