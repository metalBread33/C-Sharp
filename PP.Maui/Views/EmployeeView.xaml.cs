using PP.Library.Models;
using PP.Maui.ViewModels;

namespace PP.Maui.Views;

public partial class EmployeeView : ContentPage
{
    public Client ClientID { get; set; }
    public EmployeeView()
    {
        InitializeComponent();
        BindingContext = new EmployeeVM(); //BIndingCOntext is class where binding path is found
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeVM).Hello = "Clicked";
    }

    private void Create_Client_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeVM).Add();
        (BindingContext as EmployeeVM).RefreshView();
    }

    private void Edit_Client_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeVM).Edit();
    }

    private void View_Client_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeVM).ViewProjects();
    }

    private void Delete_Client_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeVM).Delete();
    }

    private void NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext= new EmployeeVM();
        (BindingContext as EmployeeVM).RefreshView();
    }

    private void GoHome(object sender, EventArgs eventArgs)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

}
