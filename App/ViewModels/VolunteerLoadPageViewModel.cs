using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Models;
using CsvHelper;
using ReactiveUI;
using Splat;

namespace App.ViewModels;

public class VolunteerLoadPageViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "volunteerLoad";
    public IScreen HostScreen { get; }
    private ApplicationContext Db { get; set; }
    
    private ICommand OnClickBtnView { get; set; }
    private ICommand OnClickBtnLoad { get; set; }
    private ICommand OnClickBtnCancel { get; set; }
    
    private string FileName { get; set; }

    public VolunteerLoadPageViewModel(IPageNavigation container, IScreen? screen = null)
    {
        HostScreen = screen ?? Locator.Current.GetService<IScreen>();
        Db = Singleton.GetInstance();

        OnClickBtnView = ReactiveCommand.CreateFromTask(() => Task.FromResult(GettingFile(container)));
        OnClickBtnLoad = ReactiveCommand.Create(() => CsvLoading(Db, FileName));
        OnClickBtnCancel = ReactiveCommand.Create(() => container.Back());
    }
    
    private async Task GettingFile(IPageNavigation container)
    {
        await container.OpnOpenFileDialog();
        FileName = container.GetPathToImage();
    }

    private void CsvLoading(ApplicationContext db, string fileName)
    {
        try
        {
            using var reader = new CsvReader(new StreamReader(fileName), CultureInfo.InvariantCulture);
            reader.Context.RegisterClassMap<VolunteerMap>();
            var volunteers = reader.GetRecords<Volunteer>();
            if (volunteers != null)
            {
                foreach (var volunteer in volunteers) db.Volunteers.Add(volunteer);
                db.SaveChanges();
            }
        }
        catch (Exception exception)
        {
            var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Exception!", exception.Message);
            messageBoxStandardWindow.Show();
        }
    }
}