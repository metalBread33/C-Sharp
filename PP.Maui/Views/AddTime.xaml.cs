using Microsoft.Maui.ApplicationModel.Communication;

namespace PP.Maui.Views;

[QueryProperty(nameof(EmpID), "EmpID")]

public partial class AddTime : ContentPage
{
	public AddTime()
	{
		InitializeComponent();
	}

	public int EmpID { get; set; }

    private void Back_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ViewEmp?EmpID={EmpID}");
    }

    private void Add_Clicked(object sender, EventArgs e)
    {

    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {

    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {

    }
}