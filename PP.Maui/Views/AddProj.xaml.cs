using PP.Library.Models;
using PP.Maui.ViewModels;

namespace PP.Maui.Views;

[QueryProperty(nameof(ClientID), "ClientID")]

public partial class AddProj : ContentPage
{
	public AddProj()
	{
		InitializeComponent();
        BindingContext = new AddProjVM(ClientID);
	}

    private void Create_Clicked(object sender, EventArgs e)
    {
        (BindingContext as AddProjVM).Add();
        Shell.Current.GoToAsync($"//ViewClient?ClientID={ClientID}");
    }

    private void Cancel_Clicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync($"//ViewClient?ClientID={ClientID}");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AddProjVM(ClientID);
    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    public int ClientID { get; set; }
}