using GunCatalog.Model;

namespace GunCatalog
{
    public partial class MainPage : ContentPage
    {
        private GunCatalogModel _model;

        public MainPage(GunCatalogModel model)
        {
            InitializeComponent();
            _model = model;
        }
    }

}
