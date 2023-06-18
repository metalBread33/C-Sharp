using PP.Maui.ViewModels;

namespace PP.Maui.Views;

public partial class EditProj : ContentPage
{
	public EditProj()
	{
		InitializeComponent();
	}

    private void SetActive(object sender, CheckedChangedEventArgs e)
    {

    }

    private void OK_Clicked(object sender, EventArgs e)
    {
     //   (BindingContext as EditClientVM).EditClient();
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//EditClient");
    }
}