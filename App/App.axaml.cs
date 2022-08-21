using Avalonia;
using Avalonia.Markup.Xaml;
using App.ViewModels;
using App.Views;
using App.Views.Pages;
using App.Views.Pages.Administrator;
using App.Views.Pages.Information;
using PropertyChanged;
using ReactiveUI;
using Splat;

namespace App
{
    [DoNotNotify]
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            Locator.CurrentMutable.RegisterConstant<IScreen>(new MainWindowViewModel());
            Locator.CurrentMutable.Register<IViewFor<MainMenuPageViewModel>>(() => new MainMenuPage());
            Locator.CurrentMutable.Register<IViewFor<SponsorOfRacersPageViewModel>>(() 
                => new SponsorOfRacersPage());
            Locator.CurrentMutable.Register<IViewFor<ConfirmationOfSponsorshipPageViewModel>>(() 
                => new ConfirmationOfSponsorshipPage());
            Locator.CurrentMutable.Register<IViewFor<DetailedInformationPageViewModel>>(() 
                => new DetailedInformationPage());
            Locator.CurrentMutable.Register<IViewFor<CharityListPageViewModel>>(() 
                => new CharityListPage());
            Locator.CurrentMutable.Register<IViewFor<AuthorizationMenuPageViewModel>>(() 
                => new AuthorizationMenuPage());
            Locator.CurrentMutable.Register<IViewFor<RacerMenuPageViewModel>>(() => new RacerMenuPage());
            Locator.CurrentMutable.Register<IViewFor<CoordinatorMenuPageViewModel>>(() 
                => new CoordinatorMenuPage());
            Locator.CurrentMutable.Register<IViewFor<AdministratorMenuPageViewModel>>(() 
                => new AdministratorMenuPage());
            Locator.CurrentMutable.Register<IViewFor<VerificationOfPreviouslyEnteredRacersPageViewModel>>(() 
                => new VerificationOfPreviouslyEnteredRacersPage());
            Locator.CurrentMutable.Register<IViewFor<RacerRegistrationPageViewModel>>(() 
                => new RacerRegistrationPage());
            Locator.CurrentMutable.Register<IViewFor<RaceRegistrationPageViewModel>>(() 
                => new RaceRegistrationPage());
            Locator.CurrentMutable.Register<IViewFor<ConfirmationOfRacerRegistrationPageViewModel>>(() 
                => new ConfirmationOfRacerRegistrationPage());
            Locator.CurrentMutable.Register<IViewFor<ProfileEditingPageViewModel>>(() 
                => new ProfileEditingPage());
            Locator.CurrentMutable.Register<IViewFor<MyResultsPageViewModel>>(() => new MyResultsPage());
            Locator.CurrentMutable.Register<IViewFor<PastRaceResultsPageViewModel>>(() 
                => new PastRaceResultsPage());
            Locator.CurrentMutable.Register<IViewFor<KartSkills2017PageViewModel>>(() 
                => new KartSkills2017Page());
            Locator.CurrentMutable.Register<IViewFor<InventoryPageViewModel>>(() => new InventoryPage());
            Locator.CurrentMutable.Register<IViewFor<InventoryIncomingPageViewModel>>(() 
                => new InventoryIncomingPage());
            Locator.CurrentMutable.Register<IViewFor<RaceMapPageViewModel>>(() => new RaceMapPage());

            new MainWindow { DataContext = Locator.Current.GetService<IScreen>() }.Show();
            
            base.OnFrameworkInitializationCompleted();
        }
    }
}