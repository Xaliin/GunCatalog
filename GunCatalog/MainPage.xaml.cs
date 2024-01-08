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
    }
}
