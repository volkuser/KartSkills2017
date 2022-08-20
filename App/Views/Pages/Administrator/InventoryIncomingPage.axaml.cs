using App.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views.Pages.Administrator;

[DoNotNotify]
public partial class InventoryIncomingPage : ReactiveUserControl<InventoryIncomingPageViewModel>
{
    public InventoryIncomingPage()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
    }
}