using GunCatalog.Model;
using GunCatalog.Persistence;

namespace GunCatalog
{
    public partial class App : Application
    {

        private MainFlyoutPage _rootPage;
        private GunCatalogModel _model;
        private IGunCatalogPersistence _persistence;

        public App()
        {
            _persistence = new GunCatalogJSONFilePersistence();
            _model = new GunCatalogModel(_persistence);
            _rootPage = new MainFlyoutPage();
            _rootPage.Flyout = new SideMenuPage(_model);
            _rootPage.BindingContext = _model;
            MainPage = _rootPage;

            _model.HomePageLoaded += _model_HomePageLoaded;
            _model.FavoritesPageLoaded += _model_FavoritesPageLoaded;
            _model.DetailsPageLoaded += _model_DetailsPageLoaded;
            _model.ProfilePageLoaded += _model_ProfilePageLoaded;
            _model.NewGunPageLoaded += _model_NewGunPageLoaded;

            InitializeComponent();
        }

        private async void _model_HomePageLoaded(object sender, EventArgs e)
        {
            if (_rootPage.NavigationPage.CurrentPage is not MainFlyoutPage)
            {
                await _rootPage.NavigationPage.PopToRootAsync();
            }
        }
        private async void _model_FavoritesPageLoaded(object sender, EventArgs e)
        {
            if (_rootPage.NavigationPage.CurrentPage is not Favorites)
            {
                await _rootPage.NavigationPage.PushAsync(new Favorites(_model));
            }
        }
        private async void _model_DetailsPageLoaded(object sender, EventArgs e)
        {
            if (_rootPage.NavigationPage.CurrentPage is not GunDetails)
            {
                await _rootPage.NavigationPage.PushAsync(new GunDetails(_model));
            }
        }
        private async void _model_ProfilePageLoaded(object sender, EventArgs e)
        {
            if (_rootPage.NavigationPage.CurrentPage is not Profile)
            {
                await _rootPage.NavigationPage.PushAsync(new Profile(_model));
            }
        }

        private async void _model_NewGunPageLoaded(object? sender, EventArgs e)
        {
            if (_rootPage.NavigationPage.CurrentPage is not NewGunPage)
            {
                await _rootPage.NavigationPage.PushAsync(new NewGunPage(_model));
            }
        }
    }
}
