using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using App.Models;
using App.Models.FromDatabase;
using App.Models.OnlyView;
using ReactiveUI;
using Splat;

namespace App.ViewModels.AdministratorMenu;

public class InventoryPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "inventory";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ICommand OnClickBtnReport { get; set; }
    private ICommand OnClickBtnIncoming { get; set; }
    
    private ObservableCollection<IncomingInventory>? IncomingInventories { get; set; }

    private int RacerCount { get; set; }
    private InventoryControl? InventoryControl { get; set; }

    public InventoryPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        if (Db.IncomingInventories != null) IncomingInventories
            = new(Db.IncomingInventories);

        RacerCount = GetRacerCount(Db);
        if (IncomingInventories != null) InventoryControl = GetInventoryControl(Db, IncomingInventories);

        OnClickBtnIncoming = ReactiveCommand.Create(container.OpnInventoryIncomingPage);
        OnClickBtnReport = ReactiveCommand.Create(container.OpnReportPrintPage);
    }

    private int GetRacerCount(ApplicationContext db)
    {
        int racerCount = 0;

        if (db.Registrations == null) return racerCount;
        List<Registration> registrations = new (db.Registrations);
        List<Registration> tempRegistrations = new();
        bool add = true;
        foreach (var registration in registrations)
        {
            foreach (var tempRegistration in tempRegistrations)
            {
                if (tempRegistration.ID_Racer == registration.ID_Racer)
                {
                    add = false;
                    break;
                }
            }

            if (add)
            {
                tempRegistrations.Add(registration);
                racerCount++;
            }
            else add = true;
        }

        return racerCount;
    }
    
    private InventoryControl GetInventoryControl(ApplicationContext db, 
        ObservableCollection<IncomingInventory>? incomingInventories)
    {
        InventoryControl ic = new();

        if (db.Registrations != null)
        {
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
        }

        int braceletsOnWarehouse = 0, helmetsOnWarehouse = 0, equipmentsOnWarehouse = 0;
        if (incomingInventories != null)
            foreach (var incoming in incomingInventories)
            {
                braceletsOnWarehouse += incoming.Bracelet;
                helmetsOnWarehouse += incoming.Helmet;
                equipmentsOnWarehouse += incoming.Equipment;
            }

        if (braceletsOnWarehouse > ic.BraceletNecessary)
            ic.BraceletResidue = braceletsOnWarehouse - ic.BraceletNecessary;
        else if (braceletsOnWarehouse < ic.BraceletNecessary)
            ic.BraceletAlsoNecessary = Math.Abs(braceletsOnWarehouse - ic.BraceletNecessary);
        if (helmetsOnWarehouse > ic.HelmetNecessary)
            ic.HelmetResidue = helmetsOnWarehouse - ic.HelmetNecessary;
        else if (helmetsOnWarehouse < ic.HelmetNecessary)
            ic.HelmetAlsoNecessary = Math.Abs(helmetsOnWarehouse - ic.HelmetNecessary);
        if (equipmentsOnWarehouse > ic.EquipmentNecessary)
            ic.EquipmentResidue = equipmentsOnWarehouse - ic.EquipmentNecessary;
        else if (equipmentsOnWarehouse < ic.EquipmentNecessary)
            ic.EquipmentAlsoNecessary = Math.Abs(equipmentsOnWarehouse - ic.EquipmentNecessary);

        return ic;
    }
}