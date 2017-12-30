using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Plugin.FirebasePushNotification;

namespace Push.Sample
{
    public partial class App : Application
    {

        private static ILogService _logService;

        public static ILogService LogService
        {
            get
            {
                if(_logService == null)
                {
                    _logService = DependencyService.Get<ILogService>();
                }
                return _logService;
            }
        }

        static App()
        {
        }

        public App ()
        {
            InitializeComponent();
            MainPage = new Push.Sample.MainPage();
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
            LogService.Info("Push.Sample", "App.Start -- Start");
            CrossFirebasePushNotification.Current.Subscribe("command");
            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;
            LogService.Info("Push.Sample", $"TOKEN: {CrossFirebasePushNotification.Current.Token}");
            LogService.Info("Push.Sample", "App.Start -- End");
        }

        private void Current_OnTokenRefresh(object source, Plugin.FirebasePushNotification.Abstractions.FirebasePushNotificationTokenEventArgs e)
        {
            LogService.Info("Push.Sample", $"TOKEN REC: {e.Token}");
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}
