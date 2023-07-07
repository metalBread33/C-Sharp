using PP.Library.Models;
using PP.Maui.ViewModels;

namespace PP.Maui.Views;

[QueryProperty(nameof(ProjID), "ProjID")]
[QueryProperty(nameof(ClientID), "ClientID")]

public partial class EditProj : ContentPage
{
	public EditProj()
	{
		InitializeComponent();
        BindingContext = new EditProjVM(ProjID, ClientID);
	}

    private void SetActive(object sender, CheckedChangedEventArgs e)
    {
        (BindingContext as EditProjVM).FlipClosed();
    }

    private void OK_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EditProjVM).EditProj();
        (BindingContext as EditProjVM).Back();
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EditProjVM).Back();
    }

    public int ProjID { get; set; }
    public int ClientID { get; set; }
}