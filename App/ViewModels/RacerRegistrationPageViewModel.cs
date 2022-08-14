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
    private ICommand OnClickBtnRegistration { get; set; }
    private ICommand OnClickBtnCancel { get; set; }
    
    // as user-racer
    private string FirstName { get; set; }
    private string LastName { get; set; }
    
    // as user
    private string Email { get; set; }
    private string Password { get; set; }
    private string RepeatPassword { get; set; }
    
    // as racer
    private Gender Gender { get; set; }
    private DateTimeOffset DateOfBirth { get; set; } = new DateTimeOffset(DateTime.Today);
    private Country Country { get; set; }

    // as file
    private string PathToImage { get; set; } 
    
    private ObservableCollection<Gender> Genders { get; set; }
    private ObservableCollection<Country> Countries { get; set; }
    
    private ObservableCollection<DbFile> DbFiles { get; set; }
    private ObservableCollection<User> Users { get; set; }
    private ObservableCollection<Racer> Racers { get; set; }

    public RacerRegistrationPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
        
        Genders = new(Db.Genders);
        Countries = new(Db.Countries);
        
        DbFiles = new (Db.DbFiles);
        Users = new (Db.Users);
        Racers = new (Db.Racers);
        
        OnClickBtnView = ReactiveCommand.CreateFromTask(() => Task.FromResult(ViewImage(container)));
        OnClickBtnRegistration = ReactiveCommand.Create(() => Registration(Db, PathToImage, DbFiles, FirstName, 
            LastName, Email, Password, RepeatPassword, Users, Gender, DateOfBirth, Country, Racers));
        OnClickBtnCancel = ReactiveCommand.Create(() => container.Back());
    }

    private async Task ViewImage(IPageNavigation container)
    {
        await container.OpnOpenFileDialog();
        PathToImage = container.GetPathToImage();
    }
    
    private void Registration(ApplicationContext db, string pathToImage, ObservableCollection<DbFile> dbFiles,
        string firstName, string lastName, string email, string password, string repeatPassword, 
        ObservableCollection<User> users, Gender gender, DateTimeOffset dateOfBirth, Country country,
        ObservableCollection<Racer> racers)
    {
        DbFile dbFile = new DbFile();
        if (pathToImage != null)
        {
            string shortFileName = pathToImage.Substring(pathToImage.LastIndexOf('/') + 1); // only unix
            Image image = Image.Load(pathToImage);
            byte[] imageData;
            using (var ms = new MemoryStream())
            {
                image.Save(ms, new PngEncoder());
                imageData = ms.ToArray();
            }
            dbFile = new DbFile
            {
                FileName = shortFileName,
                FileItself = imageData
            };
        }
        
        User user = new User()
        {
            Email = email,
            Password = password,
            RepeatPassword = repeatPassword,
            First_Name = firstName,
            Last_Name = lastName,
            ID_Role = 'R' // racer
        };

        DateTime dateOfBirthInDateTime = dateOfBirth.Date;
        Racer racer = new Racer()
        {
            First_Name = firstName,
            Last_Name = lastName,
            FullGender = gender,
            DateOfBirth = dateOfBirthInDateTime,
            Country = country
        };

        if (ApplicationContext.IsValid(user) && ApplicationContext.IsValid(racer) 
                                             && user.PasswordCompare() && racer.CorrectDateOfBirth())
        {
            if (dbFile != null)
            {
                dbFiles.Add(dbFile);
                db.DbFiles.Add(dbFile);
                db.SaveChanges();

                racer.File = dbFiles[^1];
            }
            
            users.Add(user);
            db.Users.Add(user);
            db.SaveChanges();
            
            racers.Add(racer);
            db.Racers.Add(racer);
            db.SaveChanges();
        }
    }
}