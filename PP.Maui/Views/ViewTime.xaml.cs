using Microsoft.Maui.ApplicationModel.Communication;
using PP.Library.Models;
using PP.Maui.ViewModels;

namespace PP.Maui.Views;

[QueryProperty(nameof(EmpID), "EmpID")]
[QueryProperty(nameof(time), "time")]

public partial class ViewTime : ContentPage
{
	public ViewTime()
	{
		InitializeComponent();
        BindingContext=new ViewTimeVM(EmpID, time);
	}

	public int EmpID { get; set; }
    public int time { get; set; }


    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ViewTimeVM(EmpID, time);
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        (BindingContext as ViewTimeVM).Back();
    }
}