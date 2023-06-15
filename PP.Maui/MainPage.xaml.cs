using System.Net.Security;
using PP.Library.Models;
using PP.Maui.ViewModels;

namespace PP.Maui
{
    [QueryProperty(nameof(ClientID), "clientID")]

    public partial class MainPage : ContentPage
    {

        public Client ClientID { get; set; }
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
            (BindingContext as MainViewModel).Add();
        }

        private void Edit_Client_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//EditClient");
        }

        private void View_Client_Clicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).ViewProjects();
        }

        private void Delete_Client_Clicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).Delete();
        }

        private void NavigatedTo(object sender, NavigatedToEventArgs e)
        {
            (BindingContext as MainViewModel).RefreshView();
        }

        private void RefreshView()
        {

        }
    }
}