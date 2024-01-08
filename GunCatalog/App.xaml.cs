using GunCatalog.Model;
using GunCatalog.Persistence;

namespace GunCatalog
{
    public partial class App : Application
    {

        private GunCatalogModel _model;
        private GunCatalogJSONFilePersistence _persistence;

        public App()
        {
            InitializeComponent();

            _persistence = new GunCatalogJSONFilePersistence();
            _model = new GunCatalogModel(_persistence);

            MainPage = new MainPage(_model);
            //MainPage = new TabbedPageDemo();
        }
    }
}
