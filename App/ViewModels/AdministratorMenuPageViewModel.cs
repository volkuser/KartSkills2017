using System.Windows.Input;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class AdministratorMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "administratorMenu";
    public IScreen HostScreen { get; }

    private ICommand OnClickBtnInventory { get; set; }

    public AdministratorMenuPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();

        OnClickBtnInventory = ReactiveCommand.Create(() => container.OpnInventoryPage());
    }
}