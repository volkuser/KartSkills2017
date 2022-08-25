using System.Windows.Input;
using ReactiveUI;
using Splat;

namespace App.ViewModels.AdministratorMenu;

public class AdministratorMenuPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "administratorMenu";
    public IScreen HostScreen { get; }

    private ICommand OnClickBtnInventory { get; set; }
    private ICommand OnClickBtnCharity { get; set; }
    private ICommand OnClickBtnVolunteers { get; set; }

    public AdministratorMenuPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();

        OnClickBtnInventory = ReactiveCommand.Create(container.OpnInventoryPage);
        OnClickBtnCharity = ReactiveCommand.Create(container.OpnCharityControlPage);
        OnClickBtnVolunteers = ReactiveCommand.Create(container.OpnVolunteerControlPage);
    }
}