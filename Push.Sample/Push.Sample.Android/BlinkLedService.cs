using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Things.Pio;
using Android.Util;
using Android.Views;
using Android.Widget;

using Push.Sample;
using Xamarin.Forms;
using Push.Sample.Droid;

[assembly: Dependency(typeof(BlinkLedService))]

namespace Push.Sample.Droid
{
    public class BlinkLedService : IBlinkLedService
    {
        private const string LED = "BCM24";
        private const int INTERVAL_BETWEEN_BLINKS_MS = 500;
        private const string TAG = "Push.Sample";

        public async Task BlinkLed(int interval)
        {
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    Gpio ledGpio = null;
                    try
                    {
                        PeripheralManagerService service = new PeripheralManagerService();
                        ledGpio = service.OpenGpio(LED);
                        ledGpio.SetDirection(Gpio.DirectionOutInitiallyLow);
                        var stopWatch = new Stopwatch();
                        stopWatch.Start();
                        while (true)
                        {
                            ledGpio.Value = !ledGpio.Value;
                            SystemClock.Sleep(INTERVAL_BETWEEN_BLINKS_MS);
                            if (stopWatch.Elapsed.Seconds > interval) break;
                        }
                    }
                    catch (Exception e)
                    {
                        Log.Error(TAG, Java.Lang.Exception.FromException(e), "Error on Peripheral I/O API");
                    }
                    finally
                    {
                        if (ledGpio != null)
                        {
                            Log.Info(TAG, "GPIO Closing");
                            ledGpio.Close();
                            ledGpio = null;
                        }
                    }
                });
            }
            catch (Exception e)
            {
                Log.Error(TAG, Java.Lang.Exception.FromException(e) ,"Error on Blinking LED");
            }
        }
    }
}