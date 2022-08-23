using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using Splat;

namespace App.ViewModels;

public class ProfileEditingPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "profileEditingPage";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ICommand OnClickBtnView { get; set; }
    private ICommand OnClickBtnSave { get; set; }
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
    private DateTimeOffset DateOfBirth { get; set; } 
    private Country Country { get; set; }
    
    // as file
    private string PathToImage { get; set; } 
    
    private ObservableCollection<Gender> Genders { get; set; }
    private ObservableCollection<Country> Countries { get; set; }
    
    private ObservableCollection<DbFile> DbFiles { get; set; }
    private ObservableCollection<User> Users { get; set; }
    private ObservableCollection<Racer> Racers { get; set; }
    
    public ProfileEditingPageViewModel(User currentUser, IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();
        
        Genders = new(Db.Genders);
        Countries = new(Db.Countries);
        
        DbFiles = new (Db.DbFiles);
        Users = new (Db.Users);
        Racers = new (Db.Racers);
        
        // filling of fields for filling
        Email = currentUser.Email;
        FirstName = currentUser.First_Name;
        LastName = currentUser.Last_Name;
        Racer currentRacer = Db.Racers.FirstOrDefault(x => x.First_Name.Equals(currentUser.First_Name)
                                                    && x.Last_Name.Equals(currentUser.Last_Name));
        Gender = currentRacer.FullGender;
        DbFile dbFile = currentRacer.File;
        if (dbFile != null)
        {
            using (var fs = new FileStream(dbFile.FileName, FileMode.OpenOrCreate)) 
                fs.Write(dbFile.FileItself, 0, dbFile.FileItself.Length);
            PathToImage = Environment.CurrentDirectory + "/" + dbFile.FileName;
        }
        DateOfBirth = new DateTimeOffset(currentRacer.DateOfBirth);
        Country = currentRacer.Country;

        OnClickBtnView = ReactiveCommand.CreateFromTask(() => Task.FromResult(ViewImage(container)));
        OnClickBtnSave = ReactiveCommand.Create(() => Saving(Db, dbFile, PathToImage, DbFiles, FirstName, 
            LastName, currentUser, Password, RepeatPassword, currentRacer, Gender, DateOfBirth, Country));
        OnClickBtnCancel = ReactiveCommand.Create(() => container.Back());
    }
    
    private async Task ViewImage(IPageNavigation container)
    {
        await container.OpnOpenFileDialog();
        PathToImage = container.GetPathToImage();
    }
    
    private void Saving(ApplicationContext db, DbFile dbFile, string pathToImage, ObservableCollection<DbFile> dbFiles,
        string firstName, string lastName, User user, string password, string repeatPassword, Racer racer,
        Gender gender, DateTimeOffset dateOfBirth, Country country)
    {
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

            if (dbFile != null)
            {
                dbFile.FileName = shortFileName;
                dbFile.FileItself = imageData;
            }
            else
            {
                dbFile = new DbFile()
                {
                    FileName = shortFileName,
                    FileItself = imageData
                };
            }
        }

        user.Password = password;
        user.RepeatPassword = repeatPassword;
        user.First_Name = firstName;
        user.Last_Name = lastName;
        user.ID_Role = 'R'; // racer

        var dateOfBirthInDateTime = dateOfBirth.Date;
        racer.First_Name = firstName;
        racer.Last_Name = lastName;
        racer.FullGender = gender;
        if (PathToImage != null) racer.File = dbFile;
        racer.DateOfBirth = dateOfBirthInDateTime;
        racer.Country = country;

        if (ApplicationContext.IsValid(user) && ApplicationContext.IsValid(racer) 
                                             && user.PasswordCompare() && racer.CorrectDateOfBirth())
        {
            if (pathToImage != null)
            {
                if (dbFile.FileId != null) db.DbFiles.Update(dbFile);
                else 
                {
                    dbFiles.Add(dbFile);
                    db.DbFiles.Add(dbFile);
                    racer.File = dbFiles[^1];
                }
                db.SaveChanges();
            }

            db.Users.Update(user);
            db.SaveChanges();
            
            db.Racers.Update(racer);
            db.SaveChanges();
        }
    }
}