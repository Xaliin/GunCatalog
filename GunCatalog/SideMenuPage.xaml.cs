using GunCatalog.Model;

namespace GunCatalog;

public partial class SideMenuPage : ContentPage
{
    private GunCatalogModel _model;
	public SideMenuPage(GunCatalogModel model)
	{
        _model = model;
		InitializeComponent();
	}

    public SideMenuPage()
    {
        InitializeComponent();
    }

    private async void HomeButton_Clicked(object sender, EventArgs e)
    {
        await _model.LoadHomePageAsync();
    }

    private async void FavoritesButton_Clicked(object sender, EventArgs e)
    {
        await _model.LoadFavoritesPageAsync();
    }

    private async void ProfileButton_Clicked(object sender, EventArgs e)
    {
        await _model.LoadProfilePageAsync();
    }

    private async void NewGunButton_Clicked(object sender, EventArgs e)
    {
        await _model.LoadNewGunPage();
    }
}