using App.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace App.Views.Pages;

public partial class CoordinatorMenuPage : ReactiveUserControl<CoordinatorMenuPageViewModel>
{
    public CoordinatorMenuPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}