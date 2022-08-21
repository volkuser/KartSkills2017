using System;
using System.Collections.Generic;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class InventoryIncomingPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "inventoryIncoming";
    public IScreen HostScreen { get; }
    private ApplicationContext Db;

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
        OnClickBtnCancel = ReactiveCommand.Create(() => container.OpnInventoryPage());
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

        List<IncomingInventory> incomingInventories= new(db.IncomingInventories);
        int braceletsOnWarehouse = 0, helmetsOnWarehouse = 0, equipmentsOnWarehouse = 0;
        foreach (var incoming in incomingInventories)
        {
            braceletsOnWarehouse += incoming.Bracelet;
            helmetsOnWarehouse += incoming.Helmet;
            equipmentsOnWarehouse += incoming.Equipment;
        }

        db.IncomingInventories.Add(new IncomingInventory()
        {
            Bracelet = braceletCountInInt,
            Helmet = helmetCountInInt,
            Equipment = equipmentCountInInt
        });
        db.SaveChanges();
    }
}