using App.ViewModels.CoordinatorMenu;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages.CoordinatorMenu;

[DoNotNotify]
public partial class SponsorViewPage : ReactiveUserControl<SponsorViewPageViewModel>
{
    public SponsorViewPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}