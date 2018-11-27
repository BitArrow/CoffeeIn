using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.DTO;
using UWP.Services;
using UWP.Services.Interfaces;

namespace UWP.ViewModels
{
    public class ProfileViewVm : BaseVm
    {
        private readonly ICoffeeService _coffeeService;

        public ProfileViewVm()
        {
            _coffeeService = new CoffeeService();
        }

        private MyProfileDto _profile;

        public MyProfileDto Profile
        {
            get { return _profile; }
            set
            {
                _profile = value;
                RaisePropertyChanged("Profile");
            }
        }

        public async void LoadProfile()
        {
            Profile = await _coffeeService.GetProfile();
        }
    }
}
