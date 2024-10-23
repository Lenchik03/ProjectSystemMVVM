using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectSystemMauiHardNavigation.Model;

namespace ProjectSystemMauiHardNavigation.ViewModel
{
    public class LoginMVVM
    {
        public string LastName { get; set; }
        public string Password { get; set; }

        public VmCommand Save { get; set; }

        public List<User> Users { get; set; }


        public LoginMVVM()
        {
            Save = new VmCommand(async () =>
            {
                Users = await DB.GetInstance().GetUsers();
                var user = Users.FirstOrDefault(s => s.LastName == LastName && s.Password == Password);
                if (user != null)
                {
                    await Shell.Current.GoToAsync("//TasksPage");
                    Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Ошибка", "Неверный логин или пароль", "ОК");
            });
        }

    }
}
