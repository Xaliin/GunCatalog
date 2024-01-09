using GunCatalog.Model;
using GunCatalog.Persistence.DTO;

namespace GunCatalog;

public partial class Favorites : ContentPage
{
	private GunCatalogModel _model;
	public Favorites(GunCatalogModel model)
	{
		InitializeComponent();
		_model = model;
	}

	private void UpdateView()
	{
        FavoritesContainer.Children.Clear();
        foreach (var gun in _model.Guns)
        {
            if (gun.IsFavorite)
            {
                Image img = new Image() { Source = gun.Picture is null ? ImageSource.FromFile("imagenotfound.png") : ImageSource.FromStream(() => new MemoryStream(gun.Picture)) };
                FavoritesContainer.Children.Add(img);
                Label label = new Label() { Text = gun.Data.Nev };
                FavoritesContainer.Children.Add(label);
                Button button = new Button() { Text = "Details", BindingContext = gun };
                button.Clicked += GunDetailsButtonClicked;
                FavoritesContainer.Children.Add(button);
            }         
        }
    }

    private async void GunDetailsButtonClicked(object? sender, EventArgs e)
    {
        await _model.LoadDetailsPage((sender as Button).BindingContext as Gun);
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateView();
    }
}