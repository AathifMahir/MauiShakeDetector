namespace MauiShakeDetector;
public interface IShakeDetector
{
    
    /// <summary>
    /// Gets a Value Indicating Whether ShakeDetector is Supported on this Device
    /// </summary>
    bool IsSupported { get; }
    /// <summary>
    /// Gets a Value Indicating Whether ShakeDetector is Already Monitoring
    /// </summary>
    bool IsMonitoring { get; }

    /// <summary>
    /// Get or Set the Value of Shake Detection Threshold
    /// In Summary The Gforce Value for Shake To Be Detected
    /// </summary>
    double ShakeThresholdGravity { get;  set; }

    /// <summary>
    /// Get or Set the value of Minimum Delay betweem Shakes
    /// </summary>
    TimeSpan ShakeIntervalInMilliseconds { get;  set; }

    /// <summary>
    /// Get or Set the Value of Shake Reset Interval in Milliseconds
    /// </summary>
    TimeSpan ShakeResetIntervalInMilliseconds { get;  set; }

    /// <summary>
    /// Get or Set the Value for Number of Shakes Required Before Shake is Triggered
    /// </summary>
    int MinimumShakeCount { get;  set; }
    /// <summary>
    /// Gets a Value Indicating Whether Haptics is Enabled or not
    /// </summary>
    bool IsHapticsEnabled { get; set; }
    /// <summary>
    /// Gets a Value Indicating Whether Haptics Supported in this Device
    /// </summary>
    bool IsHapticsSupported { get;}
    /// <summary>
    /// Get or Set the Value Of Haptics Duration
    /// </summary>
    TimeSpan HapticsDurationInMilliseconds { get; set; } 
    /// <summary>
    /// Shake Detected Event for Detecting Whether User Shaked the Device
    /// </summary>
#nullable enable
    event EventHandler<ShakeDetectedEventArgs>? ShakeDetected;
#nullable disable

    /// <summary>
    /// Start listening for Shake Event
    /// </summary>
    /// <param name="sensorSpeed"></param>
    void StartListening(SensorSpeed sensorSpeed = SensorSpeed.Default);
    /// <summary>
    /// Stop Already Monitoring Shake Event
    /// </summary>
    void StopListening();
}
