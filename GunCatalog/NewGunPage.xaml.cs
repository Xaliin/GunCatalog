using GunCatalog.Model;
using GunCatalog.Persistence;
using GunCatalog.Persistence.DTO;

namespace GunCatalog;

public partial class NewGunPage : ContentPage
{
	private GunCatalogModel _model;

    public NewGunPage(GunCatalogModel model)
	{
		_model = model;
		InitializeComponent();
	}

    public async void TakePhotoButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            FileResult photoFile = await MediaPicker.CapturePhotoAsync();
            if (photoFile != null)
                await _model.LoadImage(await photoFile.OpenReadAsync());
        }
        catch (FeatureNotSupportedException)
        {
            // Feature is not supported on the device
        }
        catch (PermissionException)
        {
            // Permissions not granted
        }
        catch (Exception ex)
        {
            Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
        }
    }

    public async void ChoosePhotoButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            FileResult photoFile = await MediaPicker.PickPhotoAsync();
            if (photoFile != null)
                await _model.LoadImage(await photoFile.OpenReadAsync());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
        }
    }


    private void _model_NewGunPhotoLoaded(object? sender, EventArgs e)
    {
        GunImage.Source = ImageSource.FromStream(() => new MemoryStream(_model.NewGunImageBytes));
    }

    public async void AddNewGunButton_Clicked(object sender, EventArgs e)
	{
        string tipus = TipusEntry.Text;
        string nev = NevEntry.Text;
        string mukodes = MukodesEntry.Text;
        string loszer = LoszerEntry.Text;
        string tomeg = TomegEntry.Text;
        string hossz = HosszEntry.Text;
        string csohossz = CsohosszEntry.Text;
        string tarkapacitas = TarkapacitasEntry.Text;
        string lovedekSebessege = LovedekSebessegeEntry.Text;
        string szarmazas = SzarmazasEntry.Text;
        string tuzgyorsasag = TuzgyorsasagEntry.Text;

        if (String.IsNullOrEmpty(tipus) || String.IsNullOrWhiteSpace(tipus)) { await DisplayAlert("Error!", "\"Típus\" is required!", "OK"); }
        if (String.IsNullOrEmpty(nev) || String.IsNullOrWhiteSpace(nev)) { await DisplayAlert("Error!", "\"Név\" is required!", "OK"); }
        if (String.IsNullOrEmpty(loszer) || String.IsNullOrWhiteSpace(loszer)) { await DisplayAlert("Error!", "\"Lőszer\" is required!", "OK"); }
        if (String.IsNullOrEmpty(tomeg) || String.IsNullOrWhiteSpace(tomeg)) { await DisplayAlert("Error!", "\"Tömeg\" is required!", "OK"); }
        if (String.IsNullOrEmpty(hossz) || String.IsNullOrWhiteSpace(hossz)) { await DisplayAlert("Error!", "\"Hossz\" is required!", "OK"); }
        if (String.IsNullOrEmpty(tarkapacitas) || String.IsNullOrWhiteSpace(tarkapacitas)) { await DisplayAlert("Error!", "\"Tárkapacitás\" is required!", "OK"); }

        int id = _model.Guns.Max(x => x.Id);

        GunData gunData = new GunData(tipus,nev,mukodes,loszer,tomeg,hossz,csohossz,tarkapacitas,lovedekSebessege,szarmazas,tuzgyorsasag);
        Gun gun = new Gun(id, _model.NewGunImageBytes, gunData);
        _model.Guns.Add(gun);
        _model.NewGunImageBytes = null;
        await DisplayAlert("Success", "New gun added!", "OK");
        await _model.LoadHomePageAsync();
    }



    protected override void OnAppearing()
    {
        base.OnAppearing();
        _model.NewGunPhotoLoaded += _model_NewGunPhotoLoaded;
    }
}