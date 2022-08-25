using System.Windows.Input;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class ReportPrintPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "reportPrint";
    public IScreen HostScreen { get; }
    
    private ICommand OnClickBtnPrint { get; set; }
    private ICommand OnClickBtnCancel { get; set; }
    
    public ReportPrintPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();

        OnClickBtnCancel = ReactiveCommand.Create(container.Back);
    }
}