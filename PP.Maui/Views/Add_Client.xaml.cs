using PP.Maui.ViewModels;
using PP.Library.Models;

namespace PP.Maui.Views;

[QueryProperty(nameof (Id), "ClientID")]
public partial class Add_Client : ContentPage
{
	public Add_Client()
	{
		InitializeComponent();
		BindingContext = new Add_ClientVM();
	}


	public void OnLeaving(object sender, NavigatedFromEventArgs e)
	{
		BindingContext = null;
	}

	public void OnArriving(object sender, NavigatedToEventArgs e)
	{
		BindingContext = new Add_ClientVM();
	}

    private void OK_Clicked(object sender, EventArgs e)
    {
		(BindingContext as Add_ClientVM).AddClient();
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

}
