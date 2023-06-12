using PP.Maui.ViewModels;
using PP.Library.Models;
using PP.Library.Models;

namespace PP.Maui.Views;

public partial class Add_or_Edit_Client : ContentPage
{
	public Add_or_Edit_Client()
	{
		InitializeComponent();
		BindingContext = new Add_Edit_ClientVM();
	}

	public string Name
	{ get; set; }

	public void OnLeaving(object sender, NavigatedFromEventArgs e)
	{
		BindingContext = null;
	}

	public void OnArriving(object sender, NavigatedToEventArgs e)
	{
		BindingContext = new Add_or_Edit_Client();
	}
}
