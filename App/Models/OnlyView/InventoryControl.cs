namespace App.Models.OnlyView;

public class InventoryControl
{
    // top row
    public int SelectedTypeA { get; set; }
    public int SelectedTypeB { get; set; }
    public int SelectedTypeC { get; set; }

    // row with info about bracelet
    public int TypeABraceletCount { get; set; }
    public int TypeBBraceletCount { get; set; }
    public int TypeCBraceletCount { get; set; }
    public int BraceletNecessary { get; set; }
    public int BraceletResidue { get; set; }
    public int BraceletAlsoNecessary { get; set; }
    
    // row with info about helmet
    public int TypeBHelmetCount { get; set; }
    public int TypeCHelmetCount { get; set; }
    public int HelmetNecessary { get; set; }
    public int HelmetResidue { get; set; }
    public int HelmetAlsoNecessary { get; set; }

    // row with info about equipment
    public int TypeCEquipmentCount { get; set; }
    public int EquipmentNecessary { get; set; }
    public int EquipmentResidue { get; set; }
    public int EquipmentAlsoNecessary { get; set; }
}