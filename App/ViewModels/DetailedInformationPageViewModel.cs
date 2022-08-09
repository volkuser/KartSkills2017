using System.Windows.Input;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class DetailedInformationPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "/detailedInformation";
    public IScreen HostScreen { get; }
    
    public bool VisibleBtnBack { get; } = true;
    
    private ICommand OnClickBtnKartSkills2017 { get; set; }
    private ICommand OnClickBtnPreviousResults { get; set; }
    private ICommand OnClickBtnListOfCharities { get; set; }

    public DetailedInformationPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();

        OnClickBtnListOfCharities = ReactiveCommand.Create(() => container.OpnCharityListPage());
    }
}