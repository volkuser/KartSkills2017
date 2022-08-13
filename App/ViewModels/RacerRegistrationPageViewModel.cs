using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using Splat;

namespace App.ViewModels;

public class RacerRegistrationPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "racerRegistration";
    public IScreen HostScreen { get; }
    private ApplicationContext Db;
    
    private ICommand OnClickBtnView { get; set; }
    private  ICommand OnClickBtnRegistration { get; set; }
    private ICommand OnClickBtnCancel { get; set; }
    
    private string Email { get; set; }
    private string Password { get; set; }
    private string RepeatPassword { get; set; }
    private string FirstName { get; set; }
    private string LastName { get; set; }

    private string PathToImage { get; set; } 
    private ObservableCollection<Gender> Genders { get; set; }
    private Gender Gender { get; set; }
    private ObservableCollection<Country> Countries { get; set; }
    private Country Country { get; set; }
    private ObservableCollection<DbFile> DbFiles { get; set; }

    public RacerRegistrationPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
        
        Genders = new(Db.Genders);
        Countries = new(Db.Countries);
        DbFiles = new (Db.DbFiles);
        
        OnClickBtnView = ReactiveCommand.CreateFromTask(() => Task.FromResult(ViewImage(container)));
        OnClickBtnRegistration = ReactiveCommand.Create(() =>
        {
            if (PathToImage != null) Registration(PathToImage, Db, DbFiles);
        });
        OnClickBtnCancel = ReactiveCommand.Create(() => container.Back());
    }

    private async Task ViewImage(IPageNavigation container)
    {
        await container.OpnOpenFileDialog();
        PathToImage = container.GetPathToImage();
    }
    
    private void Registration(string fileName, ApplicationContext db, ObservableCollection<DbFile> dbFiles)
    {
        string shortFileName = fileName.Substring(fileName.LastIndexOf('/') + 1); // only unix
        Image image = Image.Load(fileName);
        byte[] imageData;
        using (var ms = new MemoryStream())
        {
            image.Save(ms, new PngEncoder());
            imageData = ms.ToArray();
        }

        DbFile dbFile = new DbFile
        {
            FileName = shortFileName,
            FileItself = imageData
        };
        dbFiles.Add(dbFile);
        db.DbFiles.Add(dbFile);
        db.SaveChanges();
    }
}