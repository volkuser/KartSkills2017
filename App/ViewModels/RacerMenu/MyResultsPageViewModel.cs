using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using App.Models;
using App.Models.FromDatabase;
using App.Models.OnlyView;
using ReactiveUI;
using Splat;

namespace App.ViewModels.RacerMenu;

public class MyResultsPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "myResults";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }

    private ICommand? OnClickBtnChangeCurrentCategory { get; set; }
    private ICommand OnClickBtnShowAllResults { get; set; }

    private string? ViewGender { get; set; }
    private string? AgeCategory { get; set; }
    private AgeCategory? CurrentAgeCategory { get; set; }
    private string CategoryName { get; set; } = "Место по категории";
    private List<MyResult>? RequiredResults { get; set; }
    private Category CurrentCategory { get; set; } = Category.None;

    public MyResultsPageViewModel(User? currentUser, IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        if (Db.Racers != null)
        {
            var currentRacer = Db.Racers.FirstOrDefault(x => x != null && x.First_Name != null 
                                                                       && x.Last_Name != null 
                                                                       && x.First_Name.Equals(currentUser.First_Name) 
                                                                       && x.Last_Name.Equals(currentUser.Last_Name));

            ViewGender = GetViewGender(Db, currentRacer);
            CurrentAgeCategory = GetCurrentAgeCategory(Db, currentRacer);
            AgeCategory = CurrentAgeCategory?.Title;
            RequiredResults = GetRequiredResults(Db, currentRacer/*, CurrentAgeCategory*/);

            OnClickBtnChangeCurrentCategory = ReactiveCommand.Create(() => ChangeCurrentCategory(Db, currentRacer));
        }

        OnClickBtnShowAllResults = ReactiveCommand.Create(container.OpnPastRaceResultsPage);
    }

    private string? GetViewGender(ApplicationContext db, Racer? currentRacer)
    {
        if (db.Genders == null) return string.Empty;
        var currentGender = db.Genders.FirstOrDefault(x => currentRacer != null 
                                                           && x.ID_Gender.Equals(currentRacer.Gender));
        return currentGender?.Gender_Name;
    }

    private readonly AgeCategory[] _ageCategories = new AgeCategory[6]{
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
    private AgeCategory? GetCurrentAgeCategory(ApplicationContext db, Racer? currentRacer)
    {
        if (currentRacer == null) return null;
        var racerAge = DateTime.Today.Year - currentRacer.DateOfBirth.Year;

        return _ageCategories.FirstOrDefault(ageCategory => ageCategory.From <= racerAge && racerAge <= ageCategory.To);
    }

    private enum Category { None, OneGender, OneAge }

    private void ChangeCurrentCategory(ApplicationContext db, Racer? currentRacer)
    {
        switch (CurrentCategory)
        {
            case Category.OneAge:
            case Category.None:
                CurrentCategory = Category.OneGender;
                CategoryName = "Место по возврасту";
                break;
            case Category.OneGender:
                CurrentCategory = Category.OneAge;
                CategoryName = "Место по полу";
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        RequiredResults = GetRequiredResults(db, currentRacer);
    }
    
    private List<MyResult>? GetRequiredResults(ApplicationContext db, Racer? currentRacer)
    {
        List<MyResult>? requiredResults = new();

        if (db.Registrations == null) return requiredResults;
        List<Registration> registrations = new(db.Registrations.Where(x 
            => x.Racer.Equals(currentRacer)).ToList());
        foreach (var registration in registrations)
        {
            if (db.Results == null) continue;
            List<Result> currentResults = new(db.Results.Where(x
                => x.Registration.Equals(registration)).ToList());
            foreach (var result in currentResults)
            {
                var currentMyResult = new MyResult();
                if (db.Events != null)
                {
                    var currentEvent = db.Events.FirstOrDefault(x => x != null 
                                                                     && x.ID_Event.Equals(result.ID_Event));
                    var currentRace = db.Races?.FirstOrDefault(x => x != null && currentEvent != null 
                                                                              && x.ID_Race.Equals(currentEvent.ID_Race));

                    if (currentRace != null)
                        currentMyResult.EventName = currentRace.Year_Held + " " + currentRace.Sity;

                    if (db.EventTypes != null)
                    {
                        var currentEventType = db.EventTypes.FirstOrDefault(x
                            => x != null && currentEvent != null && x.ID_Event_type.Equals(currentEvent.ID_EventType));

                        currentMyResult.RaceType = currentEventType?.Event_Type_Name;
                    }

                    currentMyResult.Time =
                        (result.RaceTime.Hours == 0 ? string.Empty : result.RaceTime.Hours + "h ") + " "
                        + result.RaceTime.Minutes + "m " + result.RaceTime.Seconds + "s";
                    currentMyResult.CommonPlace = "#" + result.BidNumber;

                    List<Result> eventResults = new(db.Results.Where(x
                        => currentEvent != null && x.ID_Event.Equals(currentEvent.ID_Event)).ToList());
                    List<Result> singleGenderResults = new();
                    List<Result> singleAgeResults = new();
                    foreach (var eventResult in eventResults)
                    {
                        var eventRegistration = db.Registrations.FirstOrDefault(x
                            => x.ID_Registration.Equals(eventResult.ID_Registration));
                        if (eventRegistration == null) continue;
                        {
                            var eventRacer = db.Racers?.FirstOrDefault(x
                                => x != null && x.ID_Racer.Equals(eventRegistration.ID_Racer));
                            if (eventRacer == null) continue;
                            if (currentRacer != null && eventRacer.Gender.Equals(currentRacer.Gender))
                                singleGenderResults.Add(eventResult);
                            if (GetCurrentAgeCategory(db, eventRacer)!
                                .Equals(GetCurrentAgeCategory(db, currentRacer)))
                                singleAgeResults.Add(eventResult);
                        }
                    }

                    foreach (var singleGenderResult in singleGenderResults)
                        singleGenderResult.GenderPlace = singleGenderResult.BidNumber;

                    for (int i = 0; i < singleGenderResults.Count; i++)
                    {
                        for (int j = i + 1; j < singleGenderResults.Count; j++)
                        {
                            if (singleGenderResults[i].GenderPlace <= singleGenderResults[j].GenderPlace) continue;
                            (singleGenderResults[i], singleGenderResults[j]) 
                                = (singleGenderResults[j], singleGenderResults[i]);
                        }
                    }

                    foreach (var singleAgeResult in singleAgeResults)
                        singleAgeResult.GenderPlace = singleAgeResult.BidNumber;

                    for (int i = 0; i < singleAgeResults.Count; i++)
                    {
                        for (int j = i + 1; j < singleAgeResults.Count; j++)
                        {
                            if (singleAgeResults[i].AgePlace <= singleAgeResults[j].AgePlace) continue;
                            (singleAgeResults[i], singleAgeResults[j]) = (singleAgeResults[j], singleAgeResults[i]);
                        }
                    }

                    switch (CurrentCategory)
                    {
                        case Category.OneAge:
                        {
                            for (int i = 1; i < singleGenderResults.Count; i++)
                                //singleGenderResults[i].GenderPlace = i;
                                if (result.ID_Result == singleGenderResults[i].ID_Result)
                                    currentMyResult.SelectedCategoryPlace = "#" + i;
                            break;
                        }
                        case Category.OneGender:
                        {
                            for (int i = 1; i < singleAgeResults.Count; i++)
                                //singleAgeResults[i].AgePlace = i;
                                if (result.ID_Result == singleAgeResults[i].ID_Result)
                                    currentMyResult.SelectedCategoryPlace = "#" + i;
                            break;
                        }
                        default:
                            currentMyResult.SelectedCategoryPlace = "#?";
                            break;
                    }
                }

                requiredResults.Add(currentMyResult);
            }
        }

        return requiredResults;
    }
}