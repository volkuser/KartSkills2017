using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class CharityControlPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "charityControl";
    public IScreen HostScreen { get; }
    private ApplicationContext Db;
    
    private ICommand OnClickBtnAddNew { get; set; }

    private ObservableCollection<Charity> Charities { get; set; }

    public CharityControlPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        Charities = GetCharityList(Db);

        OnClickBtnAddNew = ReactiveCommand.Create(() => container.OpnCharityAddingOrEditingPage());
    }

    private ObservableCollection<Charity> GetCharityList(ApplicationContext db)
    {
        ObservableCollection<Charity> charities = new(db.Charities);
        
        DbFile? temp;
        foreach (var charity in charities)
        {
            temp = db.DbFiles.FirstOrDefault(x => x.FileId.Equals(charity.FileId));
            if (temp != null)
            {
                using (var fs = new FileStream(temp.FileName, FileMode.OpenOrCreate)) 
                    fs.Write(temp.FileItself, 0, temp.FileItself.Length);
                charity.FileName = Environment.CurrentDirectory + "/" + temp.FileName;
            }
        }
        
        return charities;
    }
}