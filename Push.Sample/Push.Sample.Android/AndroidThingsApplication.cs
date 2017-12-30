using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.FirebasePushNotification;

namespace Push.Sample.Droid
{
    [Application]
    public class AndroidThingsApplication : Application
    {
        public AndroidThingsApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            #if DEBUG
            FirebasePushNotificationManager.Initialize(this, true);
            #else
            FirebasePushNotificationManager.Initialize(this, false);
            #endif
        }
    }
}