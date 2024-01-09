using GunCatalog.Model;

namespace GunCatalog;

public partial class Profile : ContentPage
{
	private GunCatalogModel _model;
	public Profile(GunCatalogModel model)
	{
		InitializeComponent();
		_model = model;
	}


    public async void TakePhotoButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            FileResult photoFile = await MediaPicker.CapturePhotoAsync();
            if (photoFile != null)
                await _model.LoadProfileImage(await photoFile.OpenReadAsync());
        }
        catch (FeatureNotSupportedException)
        {
            // Feature is not supported on the device
        }
        catch (PermissionException)
        {
            // Permissions not granted
        }
        catch { }
    }

    public async void ChoosePhotoButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            FileResult photoFile = await MediaPicker.PickPhotoAsync();
            if (photoFile != null)
                await _model.LoadProfileImage(await photoFile.OpenReadAsync());
        }
        catch { }
    }

    private void UpdateView()
    {
        if(_model.UserData.ProfilePicture is null)
        {
            ProfilePicture.Source = ImageSource.FromFile("noprofile.png");
        }
        else
        {
            ProfilePicture.Source = ImageSource.FromStream(() => new MemoryStream(_model.UserData.ProfilePicture));
        }
    }

    private void _model_NewProfilePhotoLoaded(object? sender, EventArgs e)
    {
        UpdateView();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _model.NewProfilePhotoLoaded += _model_NewProfilePhotoLoaded;
        UpdateView();
    }

}