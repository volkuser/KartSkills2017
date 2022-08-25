using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Models;
using App.Models.FromDatabase;
using ReactiveUI;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using Splat;

namespace App.ViewModels.AdministratorMenu;

public class CharityAddingOrEditingPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "charityAddingOrEditingPageViewModel";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ICommand OnClickBtnView { get; set; }
    private ICommand OnClickBtnSave { get; set; }
    private ICommand OnClickBtnCancel { get; set; }
    
    private string? Title { get; set; }
    private string? Description { get; set; }
    private string? PathToImage { get; set; }
    private DbFile? File { get; set; }

    public CharityAddingOrEditingPageViewModel(IPageNavigation container, Charity? charity = null, 
        IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        OnClickBtnView = ReactiveCommand.CreateFromTask(() 
            => Task.FromResult(ViewImage(container)));
        
        if (charity == null) 
            OnClickBtnSave = ReactiveCommand.Create(() => Adding(Db, Title, Description, PathToImage));
        else
        {
            FieldsFilling(Db, charity);
            OnClickBtnSave = ReactiveCommand.Create(() => Editing(Db, charity, Title, Description, 
                PathToImage, File));
        }

        OnClickBtnCancel = ReactiveCommand.Create(container.Back);
    }
    
    private async Task ViewImage(IPageNavigation container)
    {
        await container.OpnOpenFileDialog();
        PathToImage = container.GetPathToImage();
    }
    
    private void Adding(ApplicationContext db, string? title, string? description, string? pathToImage)
    {
        Charity? charity = new Charity
        {
            Charity_Name = title,
            Charity_Description = description
        };

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
            DbFile file = new DbFile()
            {
                FileName = shortFileName,
                FileItself = imageData
            };

            charity.File = file;
        }

        db.Charities?.Add(charity);
        db.SaveChanges();
    }
    
    private void FieldsFilling(ApplicationContext db, Charity charity)
    {
        Title = charity.Charity_Name;
        Description = charity.Charity_Description;
        DbFile? dbFile = charity.File;
        if (charity.File != null)
        {
            if (dbFile != null)
            {
                using (var fs = new FileStream(dbFile.FileName, FileMode.OpenOrCreate))
                    fs.Write(dbFile.FileItself, 0, dbFile.FileItself.Length);
                PathToImage = Environment.CurrentDirectory + "/" + dbFile.FileName;
                File = dbFile;
            }
        }
    }

    private void Editing(ApplicationContext db, Charity? charity, string? title, string? description, 
        string? pathToImage, DbFile? file)
    {
        charity.Charity_Name = title;
        charity.Charity_Description = description;
        
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

            if (file != null)
            {
                file.FileName = shortFileName;
                file.FileItself = imageData;
            }
            else
            {
                file = new DbFile()
                {
                    FileName = shortFileName,
                    FileItself = imageData
                };
            }
        }

        if (ApplicationContext.IsValid(charity))
        {
            if (pathToImage != null)
            {
                if (file?.FileId != null) db.DbFiles?.Update(file);
                else 
                {
                    if (db.DbFiles != null)
                    {
                        List<DbFile?> files = new(db.DbFiles) {file};
                        db.DbFiles.Add(file);
                        charity.File = files[^1];
                    }
                }
                db.SaveChanges();
            }

            db.Charities?.Update(charity);
            db.SaveChanges();
        }
    }
}