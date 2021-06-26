using Android.App;
using Android.Content;
using Android.OS;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Android.Runtime;
using Android.Hardware;

[assembly: Dependency(typeof(StepMeter.Droid.StepCounter))]

namespace StepMeter.Droid
{
    class StepCounter : Java.Lang.Object, IStepCounter, ISensorEventListener
    {
        private int StepsCounter = 1;
        private SensorManager sManager;

        public int Steps
        {
            get { return StepsCounter; }
            set { StepsCounter = value; }
        }

        public new void Dispose()
        {
            sManager.UnregisterListener(this);
            sManager.Dispose();
        }

        public void InitSensorService()
        {
            sManager = Android.App.Application.Context.GetSystemService(Context.SensorService) as SensorManager;
            sManager.RegisterListener(this, sManager.GetDefaultSensor(SensorType.StepDetector), SensorDelay.Normal);
        }

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
            // Console.WriteLine("OnAccuracyChanged called");
        }

        public void OnSensorChanged(SensorEvent e)
        {
            switch (e.Sensor.Type)
            {
                case SensorType.StepCounter:
                    // StepsCounter++;
                    break;
                case SensorType.StepDetector:
                    StepsCounter++;
                    break;
                default:
                    break;
            }
        }

        public void StopSensorService()
        {
            sManager.UnregisterListener(this);
        }
    }
}