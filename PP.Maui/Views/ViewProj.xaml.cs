using PP.Library.Models;
using PP.Maui.ViewModels;

namespace PP.Maui.Views;

[QueryProperty(nameof(ProjID), "ProjID")]
[QueryProperty(nameof(ClientID), "ClientID")]

public partial class ViewProj : ContentPage
{
	public ViewProj()
	{
		InitializeComponent();
		BindingContext = new ViewProjVM(ProjID, ClientID);
	}

	int ProjID { get; set; }
	int ClientID { get; set; }

    private void Back_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ViewClient?ClientID={ClientID}");
    }
}