
<img src="https://github.com/AathifMahir/MauiShakeDetector/blob/master/images/icon_with_text.png" alt="MauiIcons_logo" height=200 width=450>

|**Latest Stable** | **Latest Preview**|
|  :---:     |    :---:   |
|[![AathifMahir.Maui.MauiShakeDetector](https://img.shields.io/nuget/v/AathifMahir.Maui.MauiShakeDetector)](https://www.nuget.org/packages/AathifMahir.Maui.MauiShakeDetector/) | [![AathifMahir.Maui.MauiShakeDetector](https://img.shields.io/nuget/vpre/AathifMahir.Maui.MauiShakeDetector)](https://nuget.org/packages/AathifMahir.Maui.MauiShakeDetector/absoluteLatest) |

# .Net Maui Shake Detector

Maui Shake Detector is Shake Event Detector Library Which Detects Shake Event from Android, iOS and etc. with Options to Customize the Shake Gforce and Shake Intervals and Haptics and Haptics Duration and etc.

# Permission

In order to use Maui Shake Detector, You need Specific permission for Android

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
| **IsHapticsEnabled** | `bool` | Get or Set the Value Indicating Whether Haptics is Enabled |
| **ShakeThresholdGravity** | `double` | Get or Set the Value of Shake Detection Threshold |
| **ShakeIntervalInMilliseconds** | `TimeSpan` | Get or Set the value of Minimum Delay betweem Shakes |
| **ShakeResetIntervalInMilliseconds** | `TimeSpan` | Get or Set the Value of Shake Reset Interval in Milliseconds |
| **MinimumShakeCount** | `int` | Get or Set the Value for Number of Shakes Required Before Shake is Triggered |
| **AutoStopAfterNoShakes** | `int` |  Gets or sets the value of Auto Stop listening to shake event after number of shakes triggered, Minimum is 1 |
| **HapticsDurationInMilliseconds** | `TimeSpan` | Get or Set the Value Of Haptics Duration |
| **ShakeDetectedCommand** | `ICommand` | Shake Detected Command for Detecting Whether User Shooked the Device |
| **ShakeDetected** | `event` | Shake Detected Event for Detecting Whether User Shaked the Device |
| **ShakeStoppedCommand** | `ICommand` |  Shake Stopped Command for Detecting Whether Shake Detector is Stopped When Auto Stop is more than 0 |
| **ShakeStopped** | `event` | Shake Stopped Event for Detecting Whether Shake Detector is Stopped When Auto Stop is more than 0 |
| **StartListening()** | `method` | Start listening for Shake Event |
| **SensorSpeed** | `enum` | Set the value for Shake Detection Speed When Using Start Listning Method |
| **StopListening()** | `method` | Stop Already Monitoring Shake Event |


# License

Maui Shake Detector is Licensed Under [MIT License](https://github.com/AathifMahir/MauiShakeDetector/blob/master/LICENSE.txt).

# Contribute

If you wish to contribute to this project, please don't hesitate to create an issue or request. Your input and feedback are highly appreciated. Additionally, if you're interested in supporting the project by providing resources or [**becoming a sponsor**](https://github.com/sponsors/AathifMahir), your contributions would be welcomed and instrumental in its continued development and success. Thank you for your interest in contributing to this endeavor.
