namespace App.Models;

public static class InventoryControl
{
    // top row
    public static int SelectedTypeA { get; set; }
    public static int SelectedTypeB { get; set; }
    public static int SelectedTypeC { get; set; }

    // row with info about bracelet
    public static int TypeABraceletCount { get; set; }
    public static int TypeBBraceletCount { get; set; }
    public static int TypeCBraceletCount { get; set; }
    public static int BraceletNecessary { get; set; }
    public static int BraceletResidue { get; set; }
    public static int BraceletAlsoNecessary { get; set; }
    
    // row with info about helmet
    public static int TypeBHelmetCount { get; set; }
    public static int TypeCHelmetCount { get; set; }
    public static int HelmetNecessary { get; set; }
    public static int HelmetResidue { get; set; }
    public static int HelmetAlsoNecessary { get; set; }

    // row with info about equipment
    public static int TypeCEquipmentCount { get; set; }
    public static int EquipmentNecessary { get; set; }
    public static int EquipmentResidue { get; set; }
    public static int EquipmentAlsoNecessary { get; set; }
}