using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class VolunteerControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "volunteerControl";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    /*private ICommand OnClickBtnSort { get; set; }*/
    private ICommand OnClickBtnLoad { get; set; }

    private int VolunteerCount { get; set; }
    private ObservableCollection<Volunteer> Volunteers { get; set; }

    /*private List<string> SortVariants { get; set; } = new List<string>()
    { "Фамилия", "Имя", "Страна", "Пол" };*/

    public VolunteerControlPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
        
        Volunteers = GetUpdatedVolunteer(Db);
        VolunteerCount = Volunteers.Count;

        OnClickBtnLoad = ReactiveCommand.Create(() => container.OpnVolunteerLoadPage());
    }

    private ObservableCollection<Volunteer> GetUpdatedVolunteer(ApplicationContext db)
    {
        ObservableCollection<Volunteer> volunteers = new (db.Volunteers);

        foreach (var volunteer in volunteers)
        {
            volunteer.Gender = db.Genders.FirstOrDefault(x => x.ID_Gender.Equals(volunteer.Gender_ID));
            volunteer.Country = db.Countries.FirstOrDefault(x => x.ID_Country.Equals(volunteer.ID_Country));
        }
        
        return volunteers;
    }
}