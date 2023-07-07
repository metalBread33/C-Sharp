
using PP.Maui.ViewModels;
using PP.Library.Models;

namespace PP.Maui.Views;

[QueryProperty(nameof(EmpID), "EmpID")]

public partial class EditEmployee : ContentPage
{
    public int EmpID { get; set; }

	public EditEmployee()
	{
		InitializeComponent();
        BindingContext= new EditEmployeeVM(EmpID);
	}

    private void Ok_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EditEmployeeVM).EditEmployee();
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Employer");
    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EditEmployeeVM(EmpID);
    }
}