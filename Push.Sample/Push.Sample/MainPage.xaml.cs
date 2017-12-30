using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.FirebasePushNotification;

namespace Push.Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CrossFirebasePushNotification.Current.OnNotificationReceived += Current_OnNotificationReceived;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void Current_OnNotificationReceived(object source, Plugin.FirebasePushNotification.Abstractions.FirebasePushNotificationDataEventArgs e)
        {
            App.LogService.Info("Push.Sample", "onMessageReceived");
            foreach (var data in e.Data)
            {
                App.LogService.Info("Push.Sample", $"key: {data.Key}, value: {data.Value}");
            }
            var intervalKey = "Interval";
            int interval = 0;
            var service = DependencyService.Get<IBlinkLedService>();
            interval = Convert.ToInt32(e.Data[intervalKey]);
            await service.BlinkLed(interval);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
