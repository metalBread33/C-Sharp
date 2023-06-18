using PP.Library.Models;
using PP.Maui.ViewModels;
namespace PP.Maui.Views;

[QueryProperty(nameof(ClientID), "ClientID")]
public partial class EditClient : ContentPage
{
	public EditClient()
	{
		InitializeComponent();
        BindingContext = new EditClientVM(ClientID);
	}

    public int ClientID { get; set; }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EditClientVM(ClientID);
    }

    private void SetActive(object sender, CheckedChangedEventArgs e)
    {

    }

    private void OK_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EditClientVM).EditClient();
        Shell.Current.GoToAsync("//Employee");
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Employee");
    }


}