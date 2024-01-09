using GunCatalog.Model;
using GunCatalog.Persistence.DTO;

namespace GunCatalog
{
    public partial class MainPage : ContentPage
    {
        private GunCatalogModel _model => App.Current.MainPage.BindingContext as GunCatalogModel;

        public MainPage()
        {
            InitializeComponent();
        }

        private void UpdateView()
        {
            CatalogItems.Children.Clear();
            foreach (var gun in _model.Guns)
            {
                //CatalogItems.Children.Add(new GunDisplayView(gun));
                Image img = new Image() { Source = gun.Picture is null ? ImageSource.FromFile("imagenotfound") : ImageSource.FromStream(() => new MemoryStream(gun.Picture)) };
                CatalogItems.Children.Add(img);
                Label label = new Label() { Text = gun.Data.Nev };
                CatalogItems.Children.Add(label);
                Button button = new Button() { Text = "Details", BindingContext = gun };
                button.Clicked += GunDetailsButtonClicked;
                CatalogItems.Children.Add(button);
            }
        }

        private async void GunDetailsButtonClicked(object sender, EventArgs e)
        {
            await _model.LoadDetailsPage((sender as Button).BindingContext as Gun);
        }

        private async void LearnMoreButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                Uri uri = new Uri("https://weaponsystems.net/menu/21");
                await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch { }     
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateView();
        }
    }
}
