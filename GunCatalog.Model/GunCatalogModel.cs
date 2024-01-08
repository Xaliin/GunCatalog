using GunCatalog.Persistence;
using GunCatalog.Persistence.DTO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Image = SixLabors.ImageSharp.Image;

namespace GunCatalog.Model
{
    public class GunCatalogModel
    {

        private IGunCatalogPersistence _persistence;

        public List<Gun> Guns { get; set; }
        public byte[]? NewGunImageBytes { get; set; }

        public event EventHandler? HomePageLoaded;
        public event EventHandler? FavoritesPageLoaded;
        public event EventHandler? DetailsPageLoaded;
        public event EventHandler? ProfilePageLoaded;
        public event EventHandler? NewGunPageLoaded;
        public event EventHandler? NewGunPhotoLoaded;


        public GunCatalogModel(IGunCatalogPersistence persistence) 
        { 
            _persistence = persistence;
        }

        private void OnHomePageLoaded() => HomePageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnFavoritesPageLoaded() => FavoritesPageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnDetailsPageLoaded() => DetailsPageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnProfilePageLoaded() => ProfilePageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnNewGunPageLoaded() => NewGunPageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnNewGunPhotoLoaded() => NewGunPhotoLoaded?.Invoke(this, EventArgs.Empty);


        public async Task LoadImage(Stream imageStream)
        {
            if (imageStream is not null) 
            {
                Image<Rgba32> tempImage = await Image.LoadAsync<Rgba32>(imageStream);
                tempImage.Mutate(x => x.Resize(128, 128));
                using (MemoryStream ms = new MemoryStream())
                {
                    await tempImage.SaveAsJpegAsync(ms);
                    NewGunImageBytes = ms.ToArray();
                }
            }
        }


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
        public async Task LoadNewGunPage()
        {
            OnNewGunPageLoaded();
        }
    }
}
