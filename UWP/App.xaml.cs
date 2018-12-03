using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
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
using UWP.Views;

namespace UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            RegisterServices();
            var pwVault = new PasswordVaultService();
            pwVault.LoadExistingTokens();
        }

        public static bool TestUser = false;
        public static string WebServer => "http://coffeein.eu";
        public static string WebApiEndpoint => $"{WebServer}/api/v1/";
        public static string AuthToken { get; set; }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IPasswordVaultService, PasswordVaultService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ICoffeeService, CoffeeService>();
            Container = services.BuildServiceProvider();
        }

        public static IServiceProvider Container { get; private set; }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();

                // If back button is pressed
                SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;

                // Event handler that is always activated when rootframe is navitaged
                rootFrame.Navigated += RootFrame_Navigated;

                ValidateLogin();
            }
        }

        private void ValidateLogin()
        {
            if (string.IsNullOrEmpty(AuthToken) && !TestUser)
            {
                if (Window.Current.Content is Frame rootFrame)
                {
                    rootFrame.Navigate(typeof(LoginView));
                    rootFrame.BackStack.Clear();
                }
            }
        }

        private void App_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (!e.Handled && Window.Current.Content is Frame frame && frame.CanGoBack)
            {
                frame.GoBack();
                e.Handled = true;

                if (frame.CurrentSourcePageType.Name == nameof(MainPage))
                    frame.BackStack.Clear();
            }
        }

        private void RootFrame_Navigated(object sender, NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                Window.Current.Content is Frame rootFrame && rootFrame.CanGoBack && rootFrame.CurrentSourcePageType.Name != nameof(LoginView) ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;

            ValidateLogin();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
