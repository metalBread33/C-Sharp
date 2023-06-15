using PP.Library.Models;
using PP.Maui.ViewModels;
namespace PP.Maui.Views;

[QueryProperty(nameof(ClientID), "clientID")]
public partial class EditClient : ContentPage
{
	public EditClient()
	{
		InitializeComponent();
        BindingContext = new EditClientVM();
	}

    public Client ClientID { get; set; }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EditClientVM();
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {

    }

    private void OK_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EditClientVM).EditClient();
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}