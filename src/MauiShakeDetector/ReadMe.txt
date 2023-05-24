.NET MAUI Shake Detector

## Get Started

In order to use the .NET MAUI Shake Detector you need to add below permission for Android


## Permission

In order to use Maui Shake Detector, You need Specific permission for Android


**Android**

Add the assembly-based permission:

Open the Platforms/Android/MainApplication.cs file and add the following assembly attributes after using directives:


C#

[assembly: UsesPermission(Android.Manifest.Permission.Vibrate)]


- or -


Update the Android Manifest:

Open the Platforms/Android/AndroidManifest.xml file and add the following in the manifest node:

<uses-permission android:name="android.permission.VIBRATE" />



## C# Usage


using MauiShakeDetector;

    // Start
    private void BtnStartListening_Clicked(object sender, EventArgs e)
    {
        if (ShakeDetector.Default.IsSupported && !ShakeDetector.Default.IsMonitoring)
        {
            ShakeDetector.Default.StartListening();
            ShakeDetector.Default.ShakeDetected += Detector_ShakeDetected;
            return;
        }
    }

    // Stop
    private void BtnStopListening_Clicked(object sender, EventArgs e)
    {
        if (ShakeDetector.Default.IsMonitoring)
        {
            ShakeDetector.Default.StopListening();
            ShakeDetector.Default.ShakeDetected -= Detector_ShakeDetected;
        }
    }

    private void Detector_ShakeDetected(object sender, ShakeDetectedEventArgs e)
    {
        Debug.Writeline($"No of Shakes : {e.NoOfShakes}");
    }



## Further information

For more information please visit:

- Our GitHub repository: https://github.com/AathifMahir/MauiShakeDetector