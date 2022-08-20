using System.Windows.Input;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class KartSkills2017PageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "kartSills2017";
    public IScreen HostScreen { get; }

    private ICommand OnClickBtnShowFullMap { get; set; }
    private string PathToInfo { get; set; } = "/Assets/Txt/kart-skills-2017-kart-info.txt";

    public KartSkills2017PageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
    }
}