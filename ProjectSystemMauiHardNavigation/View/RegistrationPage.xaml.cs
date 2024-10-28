using ProjectSystemMauiHardNavigation.ViewModel;
using System.Threading.Tasks;

namespace ProjectSystemMauiHardNavigation;

public partial class RegistrationPage : ContentPage
{
	
	public RegistrationPage()
	{
		InitializeComponent();

    }

    protected override void OnAppearing()
    {
        ((RegistrationMVVM)BindingContext).OnAppearing();
    }
}