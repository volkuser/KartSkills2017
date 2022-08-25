using System.IO;
using System.Windows.Input;
using ReactiveUI;
using Splat;

namespace App.ViewModels.InformationMenu;

public class KartSkills2017PageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "kartSills2017";
    public IScreen HostScreen { get; }

    private ICommand OnClickBtnShowFullMap { get; set; }
    private string PathToInfo { get; set; } 

    public KartSkills2017PageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();

        OnClickBtnShowFullMap = ReactiveCommand.Create(() => container.OpnRaceMapPage());
        
        PathToInfo = "/Assets/Txt/kart-skills-2017-kart-info.txt";
    }
}