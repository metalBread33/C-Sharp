using PP.Maui.ViewModels;

namespace PP.Maui.Views;

public partial class Add_Employee : ContentPage
{
	public Add_Employee()
	{
		InitializeComponent();
        BindingContext = new AddEmployeeVM();
	}

    private void Add_Clicked(object sender, EventArgs e)
    {
        (BindingContext as AddEmployeeVM).Add();
        Shell.Current.GoToAsync("//Employer");
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
        BindingContext = new AddEmployeeVM();
    }
}