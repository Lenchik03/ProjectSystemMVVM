using ProjectSystemMauiHardNavigation.ViewModel;

namespace ProjectSystemMauiHardNavigation;

public partial class LoginPage : ContentPage
{

	public LoginPage()
	{
		InitializeComponent();
		Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
	}

    protected override void OnAppearing()
    {
        ((LoginMVVM)BindingContext).OnAppearing();
    }

}