using System.Net.Security;
using PP.Maui.ViewModels;

namespace PP.Maui
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(); //BIndingCOntext is class where binding path is found
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).Hello = "Clicked";
        }

        private void Create_Client_Clicked(object sender, EventArgs e)
        {

        }

        private void Edit_Client_Clicked(object sender, EventArgs e)
        {

        }

        private void View_Client_Clicked(object sender, EventArgs e)
        {

        }

        private void Delete_Client_Clicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).Delete();
        }


    }
}