using App.ViewModels.RacerMenu;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages.RacerMenu;

[DoNotNotify]
public partial class ProfileEditingPage : ReactiveUserControl<ProfileEditingPageViewModel>
{
    public ProfileEditingPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}