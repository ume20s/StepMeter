using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StepMeter
{
    public interface IStepCounter
    {
        int Steps { get; set; }
        void InitSensorService();
        void StopSensorService();
    }

    public partial class MainPage : ContentPage
    {
        IStepCounter StepCounter = DependencyService.Get<IStepCounter>();

        public MainPage()
        {
            InitializeComponent();
            StepCounter.InitSensorService();
        }

        void CountClicked(object o, EventArgs e)
        {
            LabelCounter.Text = StepCounter.Steps.ToString();
        }

        void ResetClicked(object o, EventArgs e)
        {
            StepCounter.Steps = 0;
            LabelCounter.Text = StepCounter.Steps.ToString();
        }

    }
}
