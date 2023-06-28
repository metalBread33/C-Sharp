using PP.Maui.ViewModels;
namespace PP.Maui.Views;

public partial class EmployerView : ContentPage
{

	public EmployerView()
	{
		InitializeComponent();
		BindingContext = new EmployerVM();
	}

    private void GoHome(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

	private void SearchClicked(object sender, EventArgs e)
	{

	}

    private void Add_Clicked(object sender, EventArgs e)
    {
		(BindingContext as EmployerVM).Add();
		(BindingContext as EmployerVM).RefreshView();
    }

    private void Delete_Clicked(object sender, EventArgs e)
	{
		(BindingContext as EmployerVM).Delete();
	}

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
		BindingContext = null;
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		BindingContext = new EmployerVM();
		(BindingContext as EmployerVM).RefreshView();
    }

    private void Edit_Clicked(object sender, EventArgs e)
    {
		(BindingContext as EmployerVM).Edit();
    }

    private void View_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EmployerVM).View();
    }
}