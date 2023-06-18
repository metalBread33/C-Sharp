namespace PP.Maui.Views;

public partial class EmployerView : ContentPage
{

	public EmployerView()
	{
		InitializeComponent();
	}

    private void GoHome(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

	private void SearchClicked(object sender, EventArgs e)
	{

	}

	
}