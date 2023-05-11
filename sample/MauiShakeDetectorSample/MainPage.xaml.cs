using MauiShakeDetector;

namespace MauiShakeDetectorSample;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    bool isListening = false;

    int shakeCount;
    private void BtnStartListening_Clicked(object sender, EventArgs e)
    {
        if (!isListening && ShakeDetector.Default.IsSupported && !ShakeDetector.Default.IsMonitoring)
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
    }

    private void Detector_ShakeDetected(object sender, ShakeDetectedEventArgs e)
    {
        shakeCount += e.NoOfShakes;
        TxtShakeStatus.Text = $"{shakeCount} Shakes Detected and {e.NoOfShakes} Of Raw Shakes";
    }

}

