using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Models;
using ReactiveUI;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using Splat;

namespace App.ViewModels;

public class CharityAddingOrEditingPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "charityAddingOrEditingPageViewModel";
    public IScreen HostScreen { get; }
    private ApplicationContext Db;
    
    private ICommand OnClickBtnView { get; set; }
    private ICommand OnClickBtnSave { get; set; }
    private ICommand OnClickBtnCancel { get; set; }
    
    private string Title { get; set; }
    private string Description { get; set; }
    private string PathToImage { get; set; }

    public CharityAddingOrEditingPageViewModel(IPageNavigation container, Charity? charity = null, 
        IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        OnClickBtnView = ReactiveCommand.CreateFromTask(() 
            => Task.FromResult(ViewImage(container)));
        
        if (charity == null) 
            OnClickBtnSave = ReactiveCommand.Create(() => Saving(Db, Title, Description, PathToImage));
        else
        {
            FieldsFilling(Db);
            
        }

        OnClickBtnCancel = ReactiveCommand.Create(() => container.OpnCharityControlPage());
    }
    
    private async Task ViewImage(IPageNavigation container)
    {
        await container.OpnOpenFileDialog();
        PathToImage = container.GetPathToImage();
    }

    private void FieldsFilling(ApplicationContext db)
    {
        
    }

    private void Saving(ApplicationContext db, string title, string description, string pathToImage)
    {
        Charity charity = new Charity();
        charity.Charity_Name = title;
        charity.Charity_Description = description;
        charity.FileName = pathToImage;
        
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

        db.Charities.Add(charity);
        db.SaveChanges();
    }
}