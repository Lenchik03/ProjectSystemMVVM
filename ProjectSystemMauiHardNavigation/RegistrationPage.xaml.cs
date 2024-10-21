using System.Threading.Tasks;

namespace ProjectSystemMauiHardNavigation;

public partial class RegistrationPage : ContentPage
{
	public User User { get; set; } = new User();
	public RegistrationPage()
	{
		InitializeComponent();
        BindingContext = this;
    }

    private async void SaveClick(object sender, EventArgs e)
    {
        await DB.GetInstance().NewUser(User);
        await Navigation.PopAsync();
    }
}