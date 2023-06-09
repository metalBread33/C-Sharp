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
            //Hello = "Hello World";
            
        }

    }
}