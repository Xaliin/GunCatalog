using GunCatalog.Model;

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
                CatalogItems.Children.Add(new GunDisplayView(gun));
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateView();
        }
    }
}
