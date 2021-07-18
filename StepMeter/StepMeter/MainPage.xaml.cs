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
        bool IsAvailable();
    }

    public partial class MainPage : ContentPage
    {
        IStepCounter StepCounter = DependencyService.Get<IStepCounter>();

        public MainPage()
        {
            InitializeComponent();
            if (DependencyService.Get<IStepCounter>().IsAvailable())
            {
                DependencyService.Get<IStepCounter>().InitSensorService();
                TestBtn.IsVisible = true;
                TestBtn.Text = "ToolVisible";
            }
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
