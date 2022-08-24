using App.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages.Racer;

[DoNotNotify]
public partial class InformationAboutContactsWindow : ReactiveWindow<InformationAboutContactsWindowViewModel>
{
    public InformationAboutContactsWindow()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}