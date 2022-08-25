using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using App.ViewModels;
using App.Views.Pages;
using App.Views.Pages.Information;
using App.Views.Pages.Racer;
using Avalonia.Controls;
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
        this.WhenActivated(disposables =>
        {
            disposables(ViewModel!.ShowInformationAboutContactsWindow
                .RegisterHandler(ShowInformationAboutContactsWindow));
            disposables(ViewModel.ShowOpenFileDialog.RegisterHandler(ShowOpenFileDialog));
            disposables(ViewModel!.ShowInformationAboutCharityWindow
                .RegisterHandler(ShowInformationAboutCharityWindow));
            disposables(ViewModel!.ShowRacerCardWindow.RegisterHandler(ShowRacerCardWindow));
        });
        AvaloniaXamlLoader.Load(this);
    }
    
    private async Task ShowInformationAboutContactsWindow(InteractionContext<InformationAboutContactsWindowViewModel,
        InformationAboutContactsWindowViewModel?> interaction)
    {
        var dialog = new InformationAboutContactsWindow
        { DataContext = interaction.Input };

        var result = await dialog.ShowDialog<InformationAboutContactsWindowViewModel?>(this);
        interaction.SetOutput(result);
    }
    
    private async Task ShowOpenFileDialog(InteractionContext<Unit, string?> interaction)
    {
        var dialog = new OpenFileDialog();
        dialog.Filters.Add(new FileDialogFilter() { Name = "All files", Extensions = {"*"} });
        var fileNameStrings = await dialog.ShowAsync(this);
        interaction.SetOutput(fileNameStrings.FirstOrDefault());
    }
    
    private async Task ShowInformationAboutCharityWindow(InteractionContext<InformationAboutCharityWindowViewModel,
        InformationAboutCharityWindowViewModel?> interaction)
    {
        var dialog = new InformationAboutCharityWindow
            { DataContext = interaction.Input };

        var result = await dialog.ShowDialog<InformationAboutCharityWindowViewModel?>(this);
        interaction.SetOutput(result);
    }
    
    private async Task ShowRacerCardWindow(InteractionContext<RacerCardWindowViewModel, 
        RacerCardWindowViewModel?> interaction)
    {
        var dialog = new RacerCardWindow
            { DataContext = interaction.Input };

        var result = await dialog.ShowDialog<RacerCardWindowViewModel?>(this);
        interaction.SetOutput(result);
    }
}
