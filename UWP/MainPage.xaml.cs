using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Extensions.DependencyInjection;
using UWP.Services;
using UWP.Services.Interfaces;
using UWP.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IAuthService _authService;

        public MainPage()
        {
            this.InitializeComponent();

            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            _authService = App.Container.GetRequiredService<IAuthService>();
        }

        private void NavigationBtn_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as AppBarButton)?.Name)
            {
                case "MenuBtn":
                    
                    break;
                case "SpecialsBtn":

                    break;
                case "ProfileBtn":

                    break;
                case "LocationsBtn":

                    break;
                case "SettingsBtn":

                    break;
                case "LogoutBtn":
                    _authService.LogOut();
                    this.Frame.Navigate(typeof(LoginView));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
