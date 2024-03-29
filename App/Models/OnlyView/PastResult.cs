using System;
using System.Windows.Input;

namespace App.Models.OnlyView;

public class PastResult
{
    public string Position { get; set; }
    public string Time { get; set; }
    public TimeSpan TimeS { get; set; }
    public string RacerName { get; set; }
    public ICommand CmdRacerCard { get; set; }
    public string? Country { get; set; }
}