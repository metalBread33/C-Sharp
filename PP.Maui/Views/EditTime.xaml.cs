using PP.Maui.ViewModels;
namespace PP.Maui.Views;


[QueryProperty(nameof(EmpID), "EmpID")]
[QueryProperty(nameof(time), "time")]

public partial class EditTime : ContentPage
{
	public EditTime()
	{
		InitializeComponent();
        BindingContext = new EditTimeVM(EmpID, time);
	}

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EditTimeVM(EmpID, time);

    }

    private void Accept_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EditTimeVM).Edit();
        (BindingContext as EditTimeVM).Refresh();
        (BindingContext as EditTimeVM).Back();

    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        (BindingContext as EditTimeVM).Back();
    }

    public int EmpID { get; set; }
    public int time { get; set; }
}