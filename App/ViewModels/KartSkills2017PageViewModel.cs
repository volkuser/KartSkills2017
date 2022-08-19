using System.Windows.Input;
using ReactiveUI;

namespace App.ViewModels;

public class KartSkills2017PageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "charityList";
    public IScreen HostScreen { get; }

    private ICommand OnClickBtnShowFullMap { get; set; }
    private string PathToInfo { get; set; } = "/Assets/Txt/kart-skills-2017-kart-info.txt";

    public KartSkills2017PageViewModel(IScreen? screen = null) { }
}