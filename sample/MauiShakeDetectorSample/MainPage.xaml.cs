using MauiShakeDetector;

namespace MauiShakeDetectorSample;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    bool isListening = false;
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
        if (!isListening)
        {
            BtnStartListening.Text = "Stop Listening";
            isListening = true;

            ShakeDetector.Default.StartListening();
            ShakeDetector.Default.ShakeDetected += Detector_ShakeDetected;
            return;
        }

        BtnStartListening.Text = "Start Listening";
        isListening = false;
        ShakeDetector.Default.StopListening();
        ShakeDetector.Default.ShakeDetected -= Detector_ShakeDetected;
        TxtShakeStatus.Text = "Shake Detector is Stop Listening";
    }

    private void Detector_ShakeDetected(object sender, ShakeDetectedEventArgs e)
    {
        TxtShakeStatus.Text += $" and No of Shakes {e.NoOfShakes}";
    }

}

