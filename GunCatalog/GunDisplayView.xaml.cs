using GunCatalog.Persistence.DTO;

namespace GunCatalog;

public partial class GunDisplayView : ContentView
{

    //------ IMAGE
	public static readonly BindableProperty KepProperty
		= BindableProperty.Create(nameof(KepValue), typeof(ImageSource), typeof(GunDisplayView), default(ImageSource), BindingMode.OneWay, null, 
			(b, o, n) => (b as GunDisplayView).OnImageChanged(n as ImageSource));

	public ImageSource KepValue
	{
		get => (ImageSource)GetValue(KepProperty);
		set => SetValue(KepProperty, value);
	}

	private void OnImageChanged(ImageSource imageSource)
	{
		Image.Source = imageSource;
	}


    //------ TIPUS
    public static readonly BindableProperty TipusProperty
        = BindableProperty.Create(nameof(TipusValue), typeof(string), typeof(GunDisplayView), default(string), BindingMode.OneWay, null,
            (b, o, n) => (b as GunDisplayView).OnTipusChanged(n as string));

    public string TipusValue
    {
        get => (string)GetValue(TipusProperty);
        set => SetValue(TipusProperty, value);
    }

    private void OnTipusChanged(string value)
    {
        TipusLabel.Text = "Típus: " + value;
    }


    //------ NEV
    public static readonly BindableProperty NevProperty
        = BindableProperty.Create(nameof(NevValue), typeof(string), typeof(GunDisplayView), default(string), BindingMode.OneWay, null,
            (b, o, n) => (b as GunDisplayView).OnNevChanged(n as string));

    public string NevValue
    {
        get => (string)GetValue(NevProperty);
        set => SetValue(NevProperty, value);
    }

    private void OnNevChanged(string value)
    {
        NevLabel.Text = "Név: " + value;
    }


    //------ MUKODES
    public static readonly BindableProperty MukodesProperty
        = BindableProperty.Create(nameof(MukodesValue), typeof(string), typeof(GunDisplayView), default(string), BindingMode.OneWay, null,
            (b, o, n) => (b as GunDisplayView).OnMukodesChanged(n as string));

    public string MukodesValue
    {
        get => (string)GetValue(MukodesProperty);
        set => SetValue(MukodesProperty, value);
    }

    private void OnMukodesChanged(string value)
    {
        MukodesLabel.Text = "Működés: " + value;
    }


    //------ LOSZER
    public static readonly BindableProperty LoszerProperty
        = BindableProperty.Create(nameof(LoszerValue), typeof(string), typeof(GunDisplayView), default(string), BindingMode.OneWay, null,
            (b, o, n) => (b as GunDisplayView).OnLoszerChanged(n as string));

    public string LoszerValue
    {
        get => (string)GetValue(LoszerProperty);
        set => SetValue(LoszerProperty, value);
    }

    private void OnLoszerChanged(string value)
    {
        LoszerLabel.Text = "Lőszer: " + value;
    }


    //------ TOMEG
    public static readonly BindableProperty TomegProperty
        = BindableProperty.Create(nameof(TomegValue), typeof(string), typeof(GunDisplayView), default(string), BindingMode.OneWay, null,
            (b, o, n) => (b as GunDisplayView).OnTomegChanged(n as string));

    public string TomegValue
    {
        get => (string)GetValue(TomegProperty);
        set => SetValue(TomegProperty, value);
    }

    private void OnTomegChanged(string value)
    {
        TomegLabel.Text = "Tömeg: " + value;
    }


    //------ HOSSZ
    public static readonly BindableProperty HosszProperty
        = BindableProperty.Create(nameof(HosszValue), typeof(string), typeof(GunDisplayView), default(string), BindingMode.OneWay, null,
            (b, o, n) => (b as GunDisplayView).OnHosszChanged(n as string));

    public string HosszValue
    {
        get => (string)GetValue(HosszProperty);
        set => SetValue(HosszProperty, value);
    }

    private void OnHosszChanged(string value)
    {
        HosszLabel.Text = "Hossz: " + value;
    }


    //------ CSOHOSSZ
    public static readonly BindableProperty CsohosszProperty
        = BindableProperty.Create(nameof(CsohosszValue), typeof(string), typeof(GunDisplayView), default(string), BindingMode.OneWay, null,
            (b, o, n) => (b as GunDisplayView).OnCsohosszChanged(n as string));

    public string CsohosszValue
    {
        get => (string)GetValue(CsohosszProperty);
        set => SetValue(CsohosszProperty, value);
    }

    private void OnCsohosszChanged(string value)
    {
        CsohosszLabel.Text = "Cső hossz: " + value;
    }

    //------ TARKAPACITAS
    public static readonly BindableProperty TarkapacitasProperty
        = BindableProperty.Create(nameof(TarkapacitasValue), typeof(string), typeof(GunDisplayView), default(string), BindingMode.OneWay, null,
            (b, o, n) => (b as GunDisplayView).OnTarkapacitasChanged(n as string));

    public string TarkapacitasValue
    {
        get => (string)GetValue(TarkapacitasProperty);
        set => SetValue(TarkapacitasProperty, value);
    }

    private void OnTarkapacitasChanged(string value)
    {
        TarkapacitasLabel.Text = "Tárkapacitás: " + value;
    }


    //------ LOVEDEK SEBESSEGE
    public static readonly BindableProperty LovedekSebessegeProperty
        = BindableProperty.Create(nameof(LovedekSebessegeValue), typeof(string), typeof(GunDisplayView), default(string), BindingMode.OneWay, null,
            (b, o, n) => (b as GunDisplayView).OnLovedekSebessegeChanged(n as string));

    public string LovedekSebessegeValue
    {
        get => (string)GetValue(LovedekSebessegeProperty);
        set => SetValue(LovedekSebessegeProperty, value);
    }

    private void OnLovedekSebessegeChanged(string value)
    {
        LovedekSebessegeLabel.Text = "Lövedéksebesség: " + value;
    }

    //------ SZARMAZAS
    public static readonly BindableProperty SzarmazasProperty
        = BindableProperty.Create(nameof(SzarmazasValue), typeof(string), typeof(GunDisplayView), default(string), BindingMode.OneWay, null,
            (b, o, n) => (b as GunDisplayView).OnSzarmazasChanged(n as string));

    public string SzarmazasValue
    {
        get => (string)GetValue(SzarmazasProperty);
        set => SetValue(SzarmazasProperty, value);
    }

    private void OnSzarmazasChanged(string value)
    {
        SzarmazasLabel.Text = "Származás: " + value;
    }

    //------ TUZGYORSASAG
    public static readonly BindableProperty TuzgyorsasagProperty
        = BindableProperty.Create(nameof(TuzgyorsasagValue), typeof(string), typeof(GunDisplayView), default(string), BindingMode.OneWay, null,
            (b, o, n) => (b as GunDisplayView).OnTuzgyorsasagChanged(n as string));

    public string TuzgyorsasagValue
    {
        get => (string)GetValue(TuzgyorsasagProperty);
        set => SetValue(TuzgyorsasagProperty, value);
    }

    private void OnTuzgyorsasagChanged(string value)
    {
        TuzgyorsasagLabel.Text = "Tűzgyorsaság: " + value;
    }


    public GunDisplayView(Gun gun)
    {
        InitializeComponent();
        this.KepValue = gun.Picture is null ? ImageSource.FromFile("imagenotfound.png") : ImageSource.FromStream(() => new MemoryStream(gun.Picture));
        this.TipusValue = gun.Data.Tipus;
        this.NevValue = gun.Data.Nev;
        this.MukodesValue = gun.Data.Mukodes is null ? "N/A": gun.Data.Mukodes;
        this.LoszerValue = gun.Data.Loszer;
        this.TomegValue = gun.Data.Tomeg;
        this. HosszValue = gun.Data.Hossz;
        this.CsohosszValue = gun.Data.Csohossz is null ? "N/A" : gun.Data.Csohossz;
        this.TarkapacitasValue = gun.Data.Tarkapacitas;
        this.LovedekSebessegeValue = gun.Data.LovedekSebessege is null ? "N/A" : gun.Data.LovedekSebessege;
        this.SzarmazasValue = gun.Data.Szarmazas is null ? "N/A" : gun.Data.Szarmazas;
        this.TuzgyorsasagValue = gun.Data.Tuzgyorsasag is null ? "N/A" : gun.Data.Tuzgyorsasag;
    }



    public GunDisplayView()
	{
		InitializeComponent();
	}
}