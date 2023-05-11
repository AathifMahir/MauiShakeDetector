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
    /// Shake detection threshold, In short the value of gforce
    /// </summary>
    double ShakeThresholdGravity { get;  set; }

    // Minimum Delay betweem shakes
    TimeSpan ShakeIntervalInMilliseconds { get;  set; }

    // Shake counter reset time
    TimeSpan ShakeCountResetTime { get;  set; }

    // Number of shakes required before shake is triggered
    int MinimumShakeCount { get;  set; }
    // Whether haptics enabled or not
    bool IsHapticsEnabled { get; set; }
    // Whether haptics supported in the device or not
    bool IsHapticsSupported { get;}
    // Duration of haptics
    TimeSpan HapticsDurationInMilliseconds { get; set; } 
    // Shake detected event for detecting whether user shaked the device
#nullable enable
    event EventHandler<ShakeDetectedEventArgs>? ShakeDetected;
#nullable disable

    // Start listening for shake event
    void StartListening();
    // Stop already monitoring shake event
    void StopListening();
}
