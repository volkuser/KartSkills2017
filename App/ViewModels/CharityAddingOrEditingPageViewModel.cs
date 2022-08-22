using System.Windows.Input;
using App.Models;
using Avalonia.Controls.Chrome;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class CharityAddingOrEditingPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "charityAddingOrEditingPageViewModel";
    public IScreen HostScreen { get; }
    private ApplicationContext Db;

    private string NameOfBtnChange { get; set; }
    
    private ICommand OnClickBtnSave { get; set; }
    private ICommand OnClickBtnCancel { get; set; }
    
    private string Title { get; set; }
    private string Description { get; set; }
    private string PathToImage { get; set; }

    public CharityAddingOrEditingPageViewModel(IPageNavigation container, IScreen? screen = null,
        Charity? charity = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        if (charity == null)
        {
            NameOfBtnChange = "Сохранить";
            OnClickBtnSave = ReactiveCommand.Create(() => Saving(Db, Title, Description, PathToImage));
        }
        else
        {
            IfAChange(Db);
        }

        OnClickBtnCancel = ReactiveCommand.Create(() => container.Back());
    }

    private void IfAChange(ApplicationContext db)
    {
        NameOfBtnChange = "Изменить";
    }

    private void Saving(ApplicationContext db, string title, string description, string pathToImage)
    {
        
    }
}