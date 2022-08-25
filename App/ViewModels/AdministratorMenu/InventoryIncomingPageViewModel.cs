using System;
using System.Windows.Input;
using App.Models;
using App.Models.FromDatabase;
using ReactiveUI;
using Splat;

namespace App.ViewModels.AdministratorMenu;

public class InventoryIncomingPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "inventoryIncoming";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }

    private ICommand OnClickBtnSave { get; set; }
    private ICommand OnClickBtnCancel { get; set; }
    
    private string? BraceletCount { get; set; }
    private string? HelmetCount { get; set; }
    private string? EquipmentCount { get; set; }

    public InventoryIncomingPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        OnClickBtnSave = ReactiveCommand.Create(() => Incoming(Db, BraceletCount, HelmetCount, EquipmentCount));
        OnClickBtnCancel = ReactiveCommand.Create(container.OpnInventoryPage);
    }

    private void Incoming(ApplicationContext db, string? braceletCount, string? helmetCount, string? equipmentCount)
    {
        int braceletCountInInt = 0, helmetCountInInt = 0, equipmentCountInInt = 0;
        try
        {
            braceletCountInInt = Convert.ToInt32(braceletCount);
            helmetCountInInt = Convert.ToInt32(helmetCount);
            equipmentCountInInt = Convert.ToInt32(equipmentCount);
        } catch (Exception) { /*ignored*/ }

        db.IncomingInventories?.Add(new IncomingInventory()
        {
            Bracelet = braceletCountInInt,
            Helmet = helmetCountInInt,
            Equipment = equipmentCountInInt
        });
        db.SaveChanges();
    }
}