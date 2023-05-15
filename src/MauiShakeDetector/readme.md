# Maui Shake Detector

Maui Shake Detector is Shake Event Detector Library Which Detects Shake Event from Android, iOS and etc. with Options to Customize the Shake Gforce and Shake Intervals and Haptics and Haptics Duration and etc.

# Permission

In order to use Maui Shake Detector, You need to Specific permission to Android

**Android**

Add the assembly-based permission:

Open the Platforms/Android/MainApplication.cs file and add the following assembly attributes after using directives:

C#

```csharp

[assembly: UsesPermission(Android.Manifest.Permission.Vibrate)]

```
- or -

Update the Android Manifest:

Open the Platforms/Android/AndroidManifest.xml file and add the following in the manifest node:

```xml

<uses-permission android:name="android.permission.VIBRATE" />

```

# Get Started

```csharp
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

```

# Parameters

| Parameters | Type | Description |
|               :---               |    :---:   |            :---:                                                                               |
| **IsSupported** | `bool` | Indicating Whether ShakeDetector is Supported on this Device |
| **IsMonitoring** | `bool` | Indicating Whether ShakeDetector is Already Monitoring |
| **IsHapticsSupported** | `bool` | Indicating Whether Haptics Supported in this Device |
| **IsHapticsEnabled** | `bool` | Get or Set the Value Indicating Whether Haptics is Enabled or Not |
| **ShakeThresholdGravity** | `double` | Get or Set the Value of Shake Detection Threshold |
| **ShakeIntervalInMilliseconds** | `TimeSpan` | Get or Set the value of Minimum Delay betweem Shakes |
| **ShakeResetIntervalInMilliseconds** | `TimeSpan` | Get or Set the Value of Shake Reset Interval in Milliseconds |
| **MinimumShakeCount** | `int` | Get or Set the Value for Number of Shakes Required Before Shake is Triggered |
| **HapticsDurationInMilliseconds** | `TimeSpan` | Get or Set the Value Of Haptics Duration |
| **ShakeDetected** | `event` | Shake Detected Event for Detecting Whether User Shaked the Device |
| **StartListening()** | `method` | Start listening for Shake Event |
| **SensorSpeed** | `enum` | Set the value for Shake Detection Speed When Using Start Listning Method |
| **StopListening()** | `method` | Stop Already Monitoring Shake Event |


# License

Maui Shake Detector is Licensed Under [MIT License](https://github.com/AathifMahir/MauiShakeDetector/blob/master/LICENSE.txt).