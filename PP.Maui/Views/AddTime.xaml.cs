using Microsoft.Maui.ApplicationModel.Communication;
using PP.Maui.ViewModels;
namespace PP.Maui.Views;

[QueryProperty(nameof(EmpID), "EmpID")]

public partial class AddTime : ContentPage
{
	public AddTime()
	{
		InitializeComponent();
        BindingContext = new AddTimeVM(EmpID);
	}

	public int EmpID { get; set; }

    private void Back_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ViewEmployee?EmpID={EmpID}");
    }

    private void Add_Clicked(object sender, EventArgs e)
    {
        (BindingContext as AddTimeVM).Add();
        Shell.Current.GoToAsync($"//ViewEmployee?EmpID={EmpID}");
    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AddTimeVM(EmpID);
    }
}