namespace ProjectSystemMauiHardNavigation;

public partial class LoginPage : ContentPage
{
	public string LastName { get; set; }
	public string Password { get; set; }

	public List<User> Users { get; set; }

	public LoginPage()
	{
		InitializeComponent();
		BindingContext = this;
		Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
	}

    private async void SignInClick(object sender, EventArgs e)
    {
		
		Users = await DB.GetInstance().GetUsers();
		var user = Users.FirstOrDefault(s => s.LastName == LastName && s.Password == Password);
		if (user != null)
		{
			await Shell.Current.GoToAsync("//TasksPage");
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        }
		else
            await DisplayAlert("Ошибка", "Неверный логин или пароль", "ОК");
    }

    
}