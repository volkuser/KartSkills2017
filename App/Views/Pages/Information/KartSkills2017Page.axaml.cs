using App.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages.Information;

[DoNotNotify]
public partial class KartSkills2017Page : ReactiveUserControl<KartSkills2017PageViewModel>
{
    public KartSkills2017Page()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}