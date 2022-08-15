using App.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages;

[DoNotNotify]
public partial class InformationAboutCharityWindow : ReactiveWindow<InformationAboutCharityWindowViewModel>
{
    public InformationAboutCharityWindow()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}