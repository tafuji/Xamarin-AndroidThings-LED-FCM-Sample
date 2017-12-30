using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using Push.Sample;
using Xamarin.Forms;
using Push.Sample.Droid;
[assembly: Dependency(typeof(LogService))]
namespace Push.Sample.Droid
{
    public class LogService : ILogService
    {
        public void Info(string TAG, string message)
        {
            Log.Info(TAG, message);
        }
    }
}