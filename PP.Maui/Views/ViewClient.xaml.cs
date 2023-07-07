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
        Shell.Current.GoToAsync($"//AddProj?ClientID={ClientID}");
    }

    private void Edit_Project_Clicked(object sender, EventArgs e)
    {
        //hell.Current.GoToAsync($"//EditProj?ClientID={ClientID}&ProjID={SelectedProject.Id}");
        (BindingContext as ViewClientVM).Edit();

    }

    private void Delete_Project_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ViewClientVM).Delete();
    }

    private void View_Project_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ViewClientVM).View();

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
        (BindingContext as ViewClientVM).RefreshView();
    }

    public Project SelectedProject { get; set; }
}