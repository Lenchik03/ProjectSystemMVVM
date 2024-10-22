using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSystemMauiHardNavigation
{
    public class RegistrationMVVM
    {
        public User User { get; set; } = new User();
        public VmCommand Save { get; set; }

        public RegistrationMVVM()
        {
            Save = new VmCommand(async () =>
            {
                await DB.GetInstance().NewUser(User);
                await Shell.Current.GoToAsync("//TasksPage");
            });
        }
    }
}
