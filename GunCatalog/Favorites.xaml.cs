using GunCatalog.Model;

namespace GunCatalog;

public partial class Favorites : ContentPage
{
	private GunCatalogModel _model;
	public Favorites(GunCatalogModel model)
	{
		InitializeComponent();
		_model = model;
	}
}