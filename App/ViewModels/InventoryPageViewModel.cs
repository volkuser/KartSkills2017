using System.Collections.Generic;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class InventoryPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "inventory";
    public IScreen HostScreen { get; }
    private ApplicationContext Db;
    
    private ICommand OnClickBtnReport { get; set; }
    private ICommand OnClickBtnIncoming { get; set; }

    private InventoryControl InventoryControl { get; set; }

    public InventoryPageViewModel(IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        InventoryControl = GetInventoryControl(Db);
    }

    private InventoryControl GetInventoryControl(ApplicationContext db)
    {
        InventoryControl ic = new();

        List<Registration> registrations = new (db.Registrations);
        int selectedTypeA = 0, selectedTypeB = 0, selectedTypeC = 0;
        foreach (var registration in registrations)
        {
            switch (registration.InventoryTypeId)
            {
                case 1: selectedTypeA++;
                    break;
                case 2: selectedTypeB++;
                    break;
                case 3: selectedTypeC++;
                    break;
            }
        }

        ic.SelectedTypeA = ic.TypeABraceletCount = selectedTypeA;
        ic.SelectedTypeB = ic.TypeBBraceletCount = ic.TypeBHelmetCount = selectedTypeB;
        ic.SelectedTypeC = ic.TypeCBraceletCount = ic.TypeCHelmetCount = ic.TypeCEquipmentCount = selectedTypeC;

        ic.BraceletNecessary = ic.HelmetNecessary = ic.EquipmentNecessary 
            = selectedTypeA + selectedTypeB + selectedTypeC;

        List<IncomingInventory> incomingInventories = new(db.IncomingInventories);
        foreach (var incoming in incomingInventories)
        {
            if (incoming.Bracelet > 0) ic.BraceletAlsoNecessary += incoming.Bracelet;
            else if (incoming.Bracelet < 0) ic.BraceletResidue += incoming.Bracelet;
            if (incoming.Helmet > 0) ic.HelmetAlsoNecessary += incoming.Helmet;
            else if (incoming.Helmet < 0) ic.BraceletResidue += incoming.Helmet;
            if (incoming.Equipment > 0) ic.EquipmentAlsoNecessary += incoming.Equipment;
            else if (incoming.Equipment < 0) ic.EquipmentResidue += incoming.Equipment;
        }

        return ic;
    }
}