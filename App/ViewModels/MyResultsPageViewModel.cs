using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class MyResultsPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "myResults";
    public IScreen HostScreen { get; }
    private ApplicationContext Db;

    private ICommand OnClickBtnChangeCurrentCategory { get; set; }
    private ICommand OnClickBtnShowAllResults { get; set; }

    private string ViewGender { get; set; }
    private string AgeCategory { get; set; }
    private AgeCategory CurrentAgeCategory { get; set; }
    private string CategoryName { get; set; } = "Место по категории";
    private List<MyResult> RequiredResults { get; set; } = new();
    private Category CurrentCategory { get; set; } = Category.None;

    public MyResultsPageViewModel(User currentUser, IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        Racer currentRacer = Db.Racers.FirstOrDefault(x => x.First_Name.Equals(currentUser.First_Name)
                                                           && x.Last_Name.Equals(currentUser.Last_Name));

        ViewGender = GetViewGender(Db, currentRacer);
        CurrentAgeCategory = GetCurrentAgeCategory(Db, currentRacer);
        AgeCategory = CurrentAgeCategory.Title;
        RequiredResults = GetRequiredResults(Db, currentRacer/*, CurrentAgeCategory*/);

        OnClickBtnChangeCurrentCategory = ReactiveCommand.Create(() => ChangeCurrentCategory(Db, currentRacer));
        OnClickBtnShowAllResults = ReactiveCommand.Create(() => container.OpnPastRaceResultsPage());
    }

    private string GetViewGender(ApplicationContext db, Racer currentRacer)
    {
        Gender currentGender = db.Genders.FirstOrDefault(x => x.ID_Gender.Equals(currentRacer.Gender));
        return currentGender.Gender_Name;
    }

    private AgeCategory[] AgeCategories = new AgeCategory[6]{
        new () {
            To = 17,
            Title = "до 18"
        },
        new() {
            From = 18,
            To = 29,
            Title = "от 18 до 29"
        },
        new() {
            From = 30,
            To = 39,
            Title = "от 30 до 39"
        },
        new() {
            From = 40,
            To = 55,
            Title = "от 40 до 55"
        },
        new() {
            From = 56,
            To = 70,
            Title = "от 56 до 70"
        },
        new() {
            From = 70,
            Title = "более 70"
        }
    };
    private AgeCategory? GetCurrentAgeCategory(ApplicationContext db, Racer currentRacer)
    {
        int racerAge = DateTime.Today.Year - currentRacer.DateOfBirth.Year;
        
        foreach (var ageCategory in AgeCategories)
            if (ageCategory.From <= racerAge && racerAge <= ageCategory.To)
                return ageCategory;
        return null;
    }

    private enum Category { None, OneGender, OneAge }

    private void ChangeCurrentCategory(ApplicationContext db, Racer currentRacer)
    {
        if (CurrentCategory == Category.OneAge || CurrentCategory == Category.None)
        {
            CurrentCategory = Category.OneGender;
            CategoryName = "Место по возврасту";
        } else if (CurrentCategory == Category.OneGender)
        {
            CurrentCategory = Category.OneAge;
            CategoryName = "Место по полу";
        }

        RequiredResults = GetRequiredResults(db, currentRacer);
    }
    
    private List<MyResult> GetRequiredResults(ApplicationContext db, Racer currentRacer)
    {
        List<MyResult> requiredResults = new();
        
        List<Registration> registrations = new(db.Registrations.Where(x 
            => x.Racer.Equals(currentRacer)).ToList());
        List<Result> currentResults = new List<Result>();
        foreach (var registration in registrations)
        { 
            currentResults = new(db.Results.Where(x
                => x.Registration.Equals(registration)).ToList());
            foreach (var result in currentResults)
            {
                MyResult currentMyResult = new MyResult();
                Event currentEvent = db.Events.FirstOrDefault(x => x.ID_Event.Equals(result.ID_Event));
                Race currentRace = db.Races.FirstOrDefault(x => x.ID_Race.Equals(currentEvent.ID_Race));
                
                currentMyResult.EventName = currentRace.Year_Held + " " + currentRace.Sity;
                
                EventType currentEventType = db.EventTypes.FirstOrDefault(x 
                    => x.ID_Event_type.Equals(currentEvent.ID_EventType));
                
                currentMyResult.RaceType = currentEventType.Event_Type_Name;
                currentMyResult.Time = (result.RaceTime.Hours == 0 ? string.Empty : result.RaceTime.Hours + "h ") + " "
                    + result.RaceTime.Minutes + "m " + result.RaceTime.Seconds + "s";
                currentMyResult.CommonPlace = "#" + result.BidNumber; 
                
                List<Result> eventResults = new(db.Results.Where(x
                    => x.ID_Event.Equals(currentEvent.ID_Event)).ToList());
                List<Result> singleGenderResults = new();
                List<Result> singleAgeResults = new();
                foreach (var eventResult in eventResults)
                {
                    Registration? eventRegistration = db.Registrations.FirstOrDefault(x 
                        => x.ID_Registration.Equals(eventResult.ID_Registration));
                    if (eventRegistration != null)
                    {
                        Racer? eventRacer = db.Racers.FirstOrDefault(x 
                            => x.ID_Racer.Equals(eventRegistration.ID_Racer));
                        if (eventRacer != null)
                        {
                            if (eventRacer.Gender.Equals(currentRacer.Gender))
                                singleGenderResults.Add(eventResult);
                            if (GetCurrentAgeCategory(db, eventRacer).Equals(GetCurrentAgeCategory(db, currentRacer)))
                                singleAgeResults.Add(eventResult);
                        }
                    }
                }

                foreach (var singleGenderResult in singleGenderResults) 
                    singleGenderResult.GenderPlace = singleGenderResult.BidNumber;
                
                int temp;
                for (int i = 0; i < singleGenderResults.Count; i++)
                {
                    for (int j = i + 1; j < singleGenderResults.Count; j++)
                    {
                        if (singleGenderResults[i].GenderPlace > singleGenderResults[j].GenderPlace)
                        {
                            temp = singleGenderResults[i].GenderPlace;
                            singleGenderResults[i].GenderPlace = singleGenderResults[j].GenderPlace;
                            singleGenderResults[j].GenderPlace = temp;
                        }                   
                    }            
                }
                
                foreach (var singleAgeResult in singleAgeResults) 
                    singleAgeResult.GenderPlace = singleAgeResult.BidNumber;
                
                int temp1;
                for (int i = 0; i < singleAgeResults.Count; i++)
                {
                    for (int j = i + 1; j < singleAgeResults.Count; j++)
                    {
                        if (singleAgeResults[i].AgePlace > singleAgeResults[j].AgePlace)
                        {
                            temp1 = singleAgeResults[i].AgePlace;
                            singleAgeResults[i].AgePlace = singleAgeResults[j].AgePlace;
                            singleAgeResults[j].AgePlace = temp1;
                        }                   
                    }            
                }

                if (CurrentCategory.Equals(Category.OneAge))
                {
                    for (int i = 1; i < singleGenderResults.Count; i++)
                        //singleGenderResults[i].GenderPlace = i;
                        if (result.ID_Result == singleGenderResults[i].ID_Result) 
                            currentMyResult.SelectedCategoryPlace = "#" + i;
                } else if (CurrentCategory.Equals(Category.OneGender))
                {
                    for (int i = 1; i < singleAgeResults.Count; i++)
                        //singleAgeResults[i].AgePlace = i;
                        if (result.ID_Result == singleAgeResults[i].ID_Result) 
                            currentMyResult.SelectedCategoryPlace = "#" + i;
                }
                else currentMyResult.SelectedCategoryPlace = "#?";

                requiredResults.Add(currentMyResult);
            }
        }

        return requiredResults;
    }
}