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
}