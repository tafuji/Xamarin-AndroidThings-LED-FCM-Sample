using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms;
using Android.Util;
using Plugin.FirebasePushNotification;

namespace Push.Sample.Droid
{
    [Activity(Label = "Push.Sample", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] { Intent.ActionMain }, Categories = new[] { Intent.CategoryLauncher })]
    [IntentFilter(new[] { Intent.ActionMain }, Categories = new[] { "android.intent.category.IOT_LAUNCHER", "android.intent.category.DEFAULT" })]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            AppDomain.CurrentDomain.UnhandledException += (s, e) => 
            {
                var ex = (Exception)e.ExceptionObject;
                var TAG = "Push.Sample";
                App.LogService.Info(TAG, ex.Message);
                App.LogService.Info(TAG, ex.StackTrace);
                App.LogService.Info(TAG, ex.GetType().ToString());
            };

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            FirebasePushNotificationManager.ProcessIntent(Intent);
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            FirebasePushNotificationManager.ProcessIntent(intent);
        }
    }
}

