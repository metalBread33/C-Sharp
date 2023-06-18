using System.Net.Security;
using PP.Library.Models;
using PP.Maui.ViewModels;

namespace PP.Maui
{

    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void Employee_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Employee");
        }

        private void Employer_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Employer");
        }
    }
}