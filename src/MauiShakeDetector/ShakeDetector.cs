namespace MauiShakeDetector;
public static class ShakeDetector
{
    public static bool IsSupported => Default.IsSupported;
    public static bool IsMonitoring => Default.IsMonitoring;
    public static double ShakeThresholdGravity => Default.ShakeThresholdGravity;
    public static TimeSpan ShakeIntervalInMilliseconds => Default.ShakeIntervalInMilliseconds;
    public static TimeSpan ShakeCountResetTime => Default.ShakeResetIntervalInMilliseconds;
    public static int MinimumShakeCount => Default.MinimumShakeCount;
    public static bool IsHapticsSupported => Default.IsHapticsSupported;
    public static bool IsHapticsEnabled => Default.IsHapticsEnabled;
    public static TimeSpan HapticsDurationInMilliseconds => Default.HapticsDurationInMilliseconds;
    public static int AutoStopAfterNoShakes => Default.AutoStopAfterNoShakes;

    public static event EventHandler<ShakeDetectedEventArgs> ShakeDetected
    {
        add => Default.ShakeDetected += value;
        remove => Default.ShakeDetected -= value;
    }

    public static void StartListening(SensorSpeed sensorSpeed) => Default.StartListening(sensorSpeed);

    public static void StopListening() => Default.StopListening();

#nullable enable
    internal static void SetDefault(IShakeDetector? implementation) =>
        defaultShakeDetector = implementation;

    static IShakeDetector? defaultShakeDetector;

    public static IShakeDetector Default =>
            defaultShakeDetector ??= new ShakeDetectorDefault();
}
