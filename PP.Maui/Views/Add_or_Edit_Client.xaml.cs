using PP.Maui.ViewModels;

namespace PP.Maui.Views;
	public partial class Add_or_Edit_Client : ContentPage
	{
		public Add_or_Edit_Client()
		{
			InitializeComponent();
			BindingContext = new Add_Edit_ClientVM();
		}
}
