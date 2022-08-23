using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class VolunteerLoadPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "volunteerLoad";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ICommand OnClickBtnView { get; set; }
    private ICommand OnClickBtnLoad { get; set; }
    private ICommand OnClickBtnCancel { get; set; }

    public VolunteerLoadPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
    }
}