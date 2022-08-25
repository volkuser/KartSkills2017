using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using App.Models;
using App.Models.FromDatabase;
using App.Models.OnlyView;
using ReactiveUI;
using Splat;

namespace App.ViewModels.CoordinatorMenu;

public class RacerControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "racerControl";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ICommand BtnOnClickUpdate { get; set; }
    
    private ObservableCollection<RegistrationStatus>? RegistrationStatuses { get; set; }
    private RegistrationStatus? SelectedRegistrationStatus { get; set; } = new();
    private ObservableCollection<EventType>? EventTypes { get; set; }
    private EventType? SelectedEventType { get; set; } = new ();

    private int RacersCount { get; set; }
    private List<ViewRacer> ViewRacers { get; set; }

    public RacerControlPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        if (Db.RegistrationStatuses != null) 
            RegistrationStatuses = new ObservableCollection<RegistrationStatus>(Db.RegistrationStatuses);
        if (Db.EventTypes != null) EventTypes = new ObservableCollection<EventType>(Db.EventTypes!);

        ViewRacers = GetViewRacers(Db, container);
        RacersCount = ViewRacers.Count;
        BtnOnClickUpdate = ReactiveCommand.Create(() =>
        {
            ViewRacers = GetViewRacers(Db, container);
            if (SelectedEventType?.ID_Event_type != null)
                ViewRacers = new(ViewRacers.Where(x 
                    => x.EventType.Equals(SelectedEventType)).ToList());
            if (SelectedRegistrationStatus?.ID_Registration_Status != null)
                ViewRacers = new(ViewRacers.Where(x 
                    => x.Status.Equals(SelectedRegistrationStatus)).ToList());
            RacersCount = ViewRacers.Count;
        });
    }

    private List<ViewRacer> GetViewRacers(ApplicationContext db, IPageNavigation container)
    {
        List<ViewRacer> viewRacers = new();

        if (db.Racers == null) return viewRacers;
        List<Racer?> racers = new(db.Racers);
        foreach (var racer in racers)
        {
            var additionRacer = new ViewRacer
            {
                FirstName = racer?.First_Name,
                LastName = racer?.Last_Name
            };

            if (db.Users == null) continue;
            var user = db.Users.FirstOrDefault(x => racer != null && x != null && x.First_Name != null 
                                                    && x.Last_Name != null 
                                                    && x.First_Name.Equals(racer.First_Name) 
                                                    && x.Last_Name.Equals(racer.Last_Name));
            additionRacer.Email = user?.Email;
            if (db.Registrations == null) continue;
            {
                var registration = db.Registrations.FirstOrDefault(x 
                    => racer != null && x.ID_Racer.Equals(racer.ID_Racer));
                if (db.RegistrationStatuses != null)
                {
                    var registrationStatus = db.RegistrationStatuses.FirstOrDefault(x
                        => registration != null 
                           && x.ID_Registration_Status.Equals(registration.ID_Registration_Status));
                    if (registrationStatus != null) additionRacer.StatusName = registrationStatus.Statu_Name;
                    additionRacer.CmdEdit = ReactiveCommand.Create(() => container.OpnProfileEditingPage(user));
            
                    viewRacers.Add(additionRacer);
            
                    if (registrationStatus != null)
                        additionRacer.Status = registrationStatus;
                }

                var result = db.Results?.FirstOrDefault(x 
                    => registration != null && x.ID_Registration.Equals(registration.ID_Registration));
                if (result == null) continue;
                {
                    if (db.Events == null) continue;
                    var currentEvent = db.Events.FirstOrDefault(x => x.ID_Event.Equals(result.ID_Event));
                    if (currentEvent == null) continue;
                    {
                        if (db.EventTypes == null) continue;
                        var eventType = db.EventTypes.FirstOrDefault(x
                            => x != null && x.ID_Event_type.Equals(currentEvent.ID_EventType));
                        additionRacer.EventType = eventType;
                    }
                }
            }
        }

        return viewRacers;
    }
}