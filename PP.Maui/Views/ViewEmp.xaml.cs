using Microsoft.Maui.ApplicationModel.Communication;
using PP.Library.Models;
using PP.Library.Services;
using PP.Maui.ViewModels;
namespace PP.Maui.Views;

[QueryProperty(nameof(EmpID), "EmpID")]
public partial class ViewEmp : ContentPage
{
	public int EmpID { get; set; }

	public ViewEmp()
	{
		InitializeComponent();
		BindingContext = new ViewEmpVm(EmpID);
	}

    private void Add_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//AddTime?EmpID={EmpID}");
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ViewEmpVm).Delete();
        refresh();
    }

    private void Edit_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//EditTime?TimeID={EmpID}");
    }

    private void View_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ViewTime?EmpID={EmpID}");
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ViewEmpVm).Back();
    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ViewEmpVm(EmpID);
        refresh();   
    }

    private void refresh()
    {
        (BindingContext as ViewEmpVm).Refresh();
    }
}