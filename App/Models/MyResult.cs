namespace App.Models;

public class MyResult
{
    public string EventName { get; set; }
    public string RaceType { get; set; }
    public string Time { get; set; }
    public string CommonPlace { get; set; }

    public string SelectedCategoryPlace { get; set; } = "#1";
}