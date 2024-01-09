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

        public UserData UserData { get; set; }
        public List<Gun> Guns => UserData.Guns;
        public Gun DetailGun { get; set; }
        public byte[]? NewGunPhotoBytes { get; set; }

        public event EventHandler? HomePageLoaded;
        public event EventHandler? FavoritesPageLoaded;
        public event EventHandler? DetailsPageLoaded;
        public event EventHandler? ProfilePageLoaded;
        public event EventHandler? NewGunPageLoaded;
        public event EventHandler? NewGunPhotoLoaded;
        public event EventHandler? NewProfilePhotoLoaded;


        public GunCatalogModel(IGunCatalogPersistence persistence) 
        { 
            Task.Run(() => LoadData());
            _persistence = persistence;
        }

        private void OnHomePageLoaded() => HomePageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnFavoritesPageLoaded() => FavoritesPageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnDetailsPageLoaded() => DetailsPageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnProfilePageLoaded() => ProfilePageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnNewGunPageLoaded() => NewGunPageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnNewGunPhotoLoaded() => NewGunPhotoLoaded?.Invoke(this, EventArgs.Empty);
        private void OnNewProfilePhotoLoaded() => NewProfilePhotoLoaded?.Invoke(this, EventArgs.Empty);


        public async Task LoadImage(Stream imageStream)
        {
            if (imageStream is not null) 
            {
                Image<Rgba32> tempImage = await Image.LoadAsync<Rgba32>(imageStream);
                //tempImage.Mutate(x => x.Resize(128, 128));
                using (MemoryStream ms = new MemoryStream())
                {
                    await tempImage.SaveAsJpegAsync(ms);
                    NewGunPhotoBytes = ms.ToArray();
                }
                OnNewGunPhotoLoaded();
            }
        }

        public async Task LoadProfileImage(Stream imageStream)
        {
            if (imageStream is not null)
            {
                Image<Rgba32> tempImage = await Image.LoadAsync<Rgba32>(imageStream);
                using (MemoryStream ms = new MemoryStream())
                {
                    await tempImage.SaveAsJpegAsync(ms);
                    UserData.ProfilePicture = ms.ToArray();
                }
                OnNewProfilePhotoLoaded();
                await SaveDataAsync();
            }
        }


        public async Task SaveDataAsync()
        {
            await _persistence.SaveData(UserData);
        }

        public async Task LoadData()
        {
            UserData = await _persistence.LoadData();
        }



        public async Task LoadHomePageAsync()
        {
            await LoadData();
            OnHomePageLoaded();
        }
        public async Task LoadFavoritesPageAsync()
        {
            OnFavoritesPageLoaded();
        }
        public async Task LoadDetailsPage(Gun gun)
        {
            DetailGun = gun;
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
