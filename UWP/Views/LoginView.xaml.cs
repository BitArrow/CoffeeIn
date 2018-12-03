using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
using UWP.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginView : Page
    {
        private readonly LoginPageVm _vm;
        private readonly IAuthService _authService;

        public LoginView()
        {
            this.InitializeComponent();
            _vm = new LoginPageVm();
            _authService = App.Container.GetRequiredService<IAuthService>();

            DataContext = _vm;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (Window.Current.Content is Frame rootFrame)
            {
                rootFrame.BackStack.Clear();
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
            }

            base.OnNavigatedFrom(e);
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (await _authService.Login(_vm.Username, PasswordPb.Password))
            {
                this.Frame.Navigate(typeof(MainPage));
            }
        }
    }
}
