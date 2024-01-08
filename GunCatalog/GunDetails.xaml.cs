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
}