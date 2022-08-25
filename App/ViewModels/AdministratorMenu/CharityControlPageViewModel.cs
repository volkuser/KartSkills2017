using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using App.Models;
using App.Models.FromDatabase;
using ReactiveUI;
using Splat;

namespace App.ViewModels.AdministratorMenu;

public class CharityControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "charityControl";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ICommand OnClickBtnAddNew { get; set; }

    private ObservableCollection<Charity?> Charities { get; set; }

    public CharityControlPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        Charities = GetCharityList(Db, container);

        OnClickBtnAddNew = ReactiveCommand.Create(() => container.OpnCharityAddingOrEditingPage());
    }

    private ObservableCollection<Charity?> GetCharityList(ApplicationContext db, IPageNavigation container)
    {
        if (db.Charities == null) return new ObservableCollection<Charity?>(); 
        ObservableCollection<Charity?> charities = new(db.Charities);

        foreach (var charity in charities)
        {
            var temp = db.DbFiles?.FirstOrDefault(x => x != null && x.FileId.Equals(charity.FileId));
            if (temp != null)
            {
                using (var fs = new FileStream(temp.FileName, FileMode.OpenOrCreate)) 
                    fs.Write(temp.FileItself, 0, temp.FileItself.Length);
                charity.FileName = Environment.CurrentDirectory + "/" + temp.FileName;
            }

            charity.CmdEdit = ReactiveCommand.Create(() 
                => container.OpnCharityAddingOrEditingPage(charity));
        }
        
        return charities;
    }
}