using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectSystemMauiHardNavigation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSystemMauiHardNavigation.ViewModel
{
    public class RegistrationMVVM: BaseVM
    {
        public User User { get; set; } = new User();
        public VmCommand Save { get; set; }

        public void OnAppearing()
        {
            Signal(nameof(User));
        }

        public RegistrationMVVM()
        {
            Save = new VmCommand(async () =>
            {
                await DB.GetInstance().NewUser(User);
                User = new User();
                await Shell.Current.GoToAsync("//LoginPage");
            });
        }
    }
}
