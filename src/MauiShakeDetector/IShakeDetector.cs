namespace MauiShakeDetector;
public interface IShakeDetector
{

    /// <summary>
    /// Gets a value indicating whether ShakeDetector is supported on this device
    /// </summary>
    bool IsSupported { get; }
    /// <summary>
    /// Gets a value indicating whether ShakeDetector is already monitoring
    /// </summary>
    bool IsMonitoring { get; }

    /// <summary>
    /// Gets or sets the value of shake detection threshold
    /// In summary, the Gforce value for shake to be detected
    /// </summary>
    double ShakeThresholdGravity { get; set; }

    /// <summary>
    /// Gets or sets the value of minimum delay between shakes
    /// </summary>
    TimeSpan ShakeIntervalInMilliseconds { get; set; }

    /// <summary>
    /// Gets or sets the value of shake reset interval in milliseconds
    /// </summary>
    TimeSpan ShakeResetIntervalInMilliseconds { get; set; }

    /// <summary>
    /// Gets or sets the value for number of shakes required before shake is triggered
    /// </summary>
    int MinimumShakeCount { get; set; }
    /// <summary>
    /// Gets a value indicating whether haptics is enabled or not
    /// </summary>
    /// <remarks>
    /// Default is true, you can disable it if you want by setting it to false
    /// </remarks>
    /// <remarks>
    /// Will throw Microsoft.Maui.ApplicationModel.FeatureNotSupportedException If MauiShakeDetector.IShakeDetector.IsHapticsSupported is false, 
    /// Therefore Please Check Whether MauiShakeDetector.IShakeDetector.IsHapticsSupported is true before enabling haptics on the device
    /// </remarks>
    bool IsHapticsEnabled { get; set; }
    /// <summary>
    /// Gets a value indicating whether haptics is supported on this device
    /// </summary>
    /// <remarks>
    /// Will throw Microsoft.Maui.ApplicationModel.FeatureNotSupportedException If MauiShakeDetector.IShakeDetector.IsHapticsSupported is false
    /// </remarks>
    bool IsHapticsSupported { get; }
    /// <summary>
    /// Gets or sets the value of haptics duration
    /// </summary>
    TimeSpan HapticsDurationInMilliseconds { get; set; }
    /// <summary>
    /// Gets or sets the value of auto stop listening to shake event after number of shakes triggered
    /// </summary>
    /// <remarks>
    /// Default is 0 and it means feature is disabled by default. You can set the count to some other value to enable this feature
    /// </remarks>
    int AutoStopAfterNoShakes { get; set; }
    /// <summary>
    /// Shake detected event for detecting whether user shook the device
    /// </summary>
#nullable enable
    event EventHandler<ShakeDetectedEventArgs>? ShakeDetected;
#nullable disable

    /// <summary>
    /// Start listening for shake event
    /// </summary>
    /// <param name="sensorSpeed">
    /// Speed to monitor the shake events.
    /// </param>
    /// <remarks>
    /// Will throw Microsoft.Maui.ApplicationModel.FeatureNotSupportedException if MauiShakeDetector.IShakeDetector.IsSupported is false.
    /// Will throw System.InvalidOperationException if MauiShakeDetector.IShakeDetector.IsMonitoring is true.
    /// </remarks>
    void StartListening(SensorSpeed sensorSpeed = SensorSpeed.Default);
    /// <summary>
    /// Stop already monitoring shake event
    /// </summary>
    void StopListening();
}
