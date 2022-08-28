using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using App.Models;
using App.Models.FromDatabase;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CoordinatorMenu;

public class ControlOfUserPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "controlOfUser";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ICommand? OnClickBtnProfileEdit { get; set; }
    
    private string? Email { get; set; }
    private string? FirstName { get; set; }
    private string? LastName { get; set; }
    private string? Gender { get; set; }
    private string? DateOfBirth { get; set; }
    private string? Country { get; set; }
    
    private string? GlobalAmount { get; set; }
    private string? PathToImage { get; set; }
    private string? EventType { get; set; }
    private string? StatusName { get; set; }

    public ControlOfUserPageViewModel(User currentUser, Registration currentRegistration, Event currentEvent, 
        IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        FillFields(Db, currentUser, currentRegistration, currentEvent);

        OnClickBtnProfileEdit = ReactiveCommand.Create(() => container.OpnEditingOfProfilePage(currentUser, 
            currentRegistration));
    }

    private void FillFields(ApplicationContext db, 
        User currentUser, Registration currentRegistration, Event currentEvent)
    {
        Email = currentUser.Email; // email
        FirstName = currentUser.First_Name; // first name
        LastName = currentUser.Last_Name; // last name
        
        var currentRacer = db.Racers!.FirstOrDefault(x => x != null && x.Last_Name != null 
                                                                      && x.First_Name!.Equals(currentUser.First_Name) 
                                                                      && x.Last_Name.Equals(currentUser.Last_Name))!;

        var currentGender = db.Genders!.FirstOrDefault(x => x!.ID_Gender.Equals(currentRacer.Gender));
        Gender = currentGender?.Gender_Name; // gender

        DateOfBirth = currentRacer.DateOfBirth.ToString("dd MMMM yyyy"); // date of birth

        var currentCountry = db.Countries!.FirstOrDefault(x => x.ID_Country.Equals(currentRacer.ID_Country));
        Country = currentCountry?.Country_Name; // country

        List<Sponsorship> sponsorships = new(db.Sponsorships!.Where(x 
            => x.ID_Racer.Equals(currentRacer.ID_Racer)));
        GlobalAmount = "$" + sponsorships.Sum(sponsorship => sponsorship.Amount); // global amount
        
        var dbFile = db.DbFiles!.FirstOrDefault(x => x!.FileId.Equals(currentRacer.FileId));
        if (dbFile != null)
        {
            using (var fs = new FileStream(dbFile.FileName, FileMode.OpenOrCreate))
                fs.Write(dbFile.FileItself, 0, dbFile.FileItself.Length);
            PathToImage = Environment.CurrentDirectory + "/" + dbFile.FileName; // path to image
        }
        
        var currentEventType = db.EventTypes!.FirstOrDefault(x 
            => x!.ID_Event_type.Equals(currentEvent.ID_EventType));
        EventType = currentEventType!.Event_Type_Name; // event type
        
        var currentRegistrationStatus = db.RegistrationStatuses!.FirstOrDefault(x 
            => x.ID_Registration_Status.Equals(currentRegistration.ID_Registration_Status));
        StatusName = currentRegistrationStatus!.Statu_Name; // status name
    }
}