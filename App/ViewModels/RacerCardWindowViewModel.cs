using System;
using System.IO;
using System.Linq;
using App.Models;

namespace App.ViewModels;

public class RacerCardWindowViewModel : ViewModelBase
{
    public string UrlPathSegment => "racerCard";
    private ApplicationContext Db { get; set; }
    
    private string PathToImage { get; set; } 
    private string RacerName { get; set; }
    private string Country { get; set; }
    private string Age { get; set; }

    public RacerCardWindowViewModel(Racer currentRacer)
    {
        Db = Singleton.GetInstance();

        DbFile file = Db.DbFiles.FirstOrDefault(x => x.FileId.Equals(currentRacer.FileId));
        if (file != null)
        {
            using (var fs = new FileStream(file.FileName, FileMode.OpenOrCreate)) 
                fs.Write(file.FileItself, 0, file.FileItself.Length);
            PathToImage = Environment.CurrentDirectory + "/" + file.FileName;
        }
        
        RacerName = currentRacer.First_Name + " " + currentRacer.Last_Name;
        
        Country country = Db.Countries.FirstOrDefault(x => x.ID_Country.Equals(currentRacer.ID_Country));
        Country = country.Country_Name;

        Age = "Полных лет " + Convert.ToString(DateTime.Today.Year - currentRacer.DateOfBirth.Year);
    }
}