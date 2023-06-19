using PP.Maui.ViewModels;
using PP.Library;
using PP.Library.Models;
using System.Collections.ObjectModel;
using PP.Library.Services;

namespace PP.Maui.Views;

[QueryProperty(nameof(ClientID), "ClientID")]
public partial class ViewClient : ContentPage
{
	public ViewClient()
	{
		InitializeComponent();
        BindingContext = new ViewClientVM(ClientID);
	}

    public int ClientID
    { get; set; }


    private void Create_Project_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddProj");
    }

    private void Edit_Project_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//EditProj");
    }

    private void Delete_Project_Clicked(object sender, EventArgs e)
    {

    }

    private void Search_Clicked(object sender, EventArgs e)
    {

    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Employee");
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ViewClientVM(ClientID);
    }
}