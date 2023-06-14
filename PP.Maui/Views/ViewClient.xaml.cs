namespace PP.Maui.Views;

public partial class ViewClient : ContentPage
{
	public ViewClient()
	{
		InitializeComponent();
        BindingContext = new ViewClient();
	}

    private void Create_Project_Clicked(object sender, EventArgs e)
    {

    }

    private void Edit_Project_Clicked(object sender, EventArgs e)
    {

    }

    private void Delete_Project_Clicked(object sender, EventArgs e)
    {

    }

    private void Search_Clicked(object sender, EventArgs e)
    {

    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}