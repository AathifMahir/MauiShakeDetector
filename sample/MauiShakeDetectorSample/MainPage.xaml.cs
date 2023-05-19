using MauiShakeDetector;
using System.Diagnostics;

namespace MauiShakeDetectorSample;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }
    private void BtnStartListening_Clicked(object sender, EventArgs e)
    {
        if (!ShakeDetector.Default.IsSupported)
        {
            TxtShakeStatus.Text = "Feature is Not Supported";
            return;
        }
        if (ShakeDetector.Default.IsMonitoring)
        {
            TxtShakeStatus.Text = "Shake Detector is ALready Running";
            return;
        }

        TxtShakeStatus.Text = "Started Listening";
        //ShakeDetector.Default.AutoStopAfterNoShakes = 5;
        ShakeDetector.Default.StartListening();
        ShakeDetector.Default.ShakeDetected += Detector_ShakeDetected;
    }

    private void Detector_ShakeDetected(object sender, ShakeDetectedEventArgs e)
    {
        TxtShakeStatus.Text = $"No of Shakes {e.NoOfShakes}";
    }

    private void BtnStopListening_Clicked(object sender, EventArgs e)
    {
        
        if(ShakeDetector.Default.IsMonitoring)
        {
            ShakeDetector.Default.StopListening();
            ShakeDetector.Default.ShakeDetected -= Detector_ShakeDetected;
            TxtShakeStatus.Text = "Shake Detector is Stop Listening";
        }
    }
}

