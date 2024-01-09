using GunCatalog.Model;

namespace GunCatalog;

public partial class GunDetails : ContentPage
{
	private GunCatalogModel _model;
	public GunDetails(GunCatalogModel model)
	{
		InitializeComponent();
		_model = model;
	}

	private void UpdateView()
	{
		DetailContainer.Children.Clear();
		if (_model is null) 
		{
			Label label = new Label() {Text = "No item selected!" };
			DetailContainer.Children.Add(label);
		}
		else
		{
			GunDisplayView displayView = new GunDisplayView(_model.DetailGun);
			DetailContainer.Children.Add(displayView);
			Button delButton = new Button() {Text = "Delete"};
			delButton.Clicked += DeleteButtonClicked;
			DetailContainer.Children.Add(delButton);
			Button favButton = new Button();
			favButton.Text = _model.DetailGun.IsFavorite ? "Remove from favorites" : "Add to favorites";
            favButton.Clicked += FavButtonClicked;
			DetailContainer.Children.Add(favButton);
		}
	}

    private async void DeleteButtonClicked(object? sender, EventArgs e)
	{
		_model.Guns.Remove(_model.DetailGun);
		await _model.SaveDataAsync();
		await _model.LoadHomePageAsync();
	}

    private async void FavButtonClicked(object? sender, EventArgs e)
    {
        if (_model.DetailGun.IsFavorite)
        {
            _model.DetailGun.IsFavorite = false;
        }
        else
        {
			_model.DetailGun.IsFavorite = true;
        }
		await _model.SaveDataAsync();
        UpdateView();
    }

    protected override void OnAppearing()
    {
		UpdateView();
        base.OnAppearing();
    }
}