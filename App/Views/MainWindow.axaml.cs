using System.Threading.Tasks;
using App.ViewModels;
using App.Views.Pages;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PropertyChanged;
using ReactiveUI;

namespace App.Views;

[DoNotNotify]
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        this.WhenActivated(d 
            => d(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
        AvaloniaXamlLoader.Load(this);
    }
    
    private async Task DoShowDialogAsync(InteractionContext<InformationAboutContactsWindowViewModel,
        InformationAboutContactsWindowViewModel?> interaction)
    {
        var dialog = new InformationAboutContactsWindow
        { DataContext = interaction.Input };

        var result = await dialog.ShowDialog<InformationAboutContactsWindowViewModel?>(this);
        interaction.SetOutput(result);
    }
}
