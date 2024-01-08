using GunCatalog.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCatalog.Model
{
    public class GunCatalogModel
    {

        private IGunCatalogPersistence _persistence;

        public event EventHandler? HomePageLoaded;
        public event EventHandler? FavoritesPageLoaded;
        public event EventHandler? DetailsPageLoaded;
        public event EventHandler? ProfilePageLoaded;


        public GunCatalogModel(IGunCatalogPersistence persistence) 
        { 
            _persistence = persistence;
        }

        private void OnHomePageLoaded() => HomePageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnFavoritesPageLoaded() => FavoritesPageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnDetailsPageLoaded() => DetailsPageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnProfilePageLoaded() => ProfilePageLoaded?.Invoke(this, EventArgs.Empty);



        public async Task LoadHomePageAsync()
        {
            OnHomePageLoaded();
        }
        public async Task LoadFavoritesPageAsync()
        {
            OnFavoritesPageLoaded();
        }
        public async Task LoadDetailsPage()
        {
            OnDetailsPageLoaded();
        }
        public async Task LoadProfilePageAsync()
        {
            OnProfilePageLoaded();
        }
    }
}
