namespace MauiShakeDetector;
internal sealed class ShakeDetectorDefault : IShakeDetector
{
    // Properties
    public bool IsSupported { get; set; } = Accelerometer.Default.IsSupported;
    public bool IsMonitoring { get; set; } = Accelerometer.Default.IsMonitoring;
    public double ShakeThresholdGravity { get; set; } = 1.9;
    public TimeSpan ShakeIntervalInMilliseconds { get; set; } = TimeSpan.FromMilliseconds(500);
    public TimeSpan ShakeResetIntervalInMilliseconds { get; set; } = TimeSpan.FromMilliseconds(3000);
    public int MinimumShakeCount { get; set; } = 1;
    public bool IsHapticsEnabled { get; set; } = true;
    public bool IsHapticsSupported { get; set; } = Vibration.Default.IsSupported;
    public TimeSpan HapticsDurationInMilliseconds { get; set; } = TimeSpan.FromMilliseconds(1700);


    // Private Fields

    TimeSpan currentShakeTimeInMilliseconds = new(DateTime.Now.Ticks);

    int currentShakeCount = 0;

    static bool useSyncContext;

    // Event Handlers

    public event EventHandler<ShakeDetectedEventArgs> ShakeDetected;

    public void StartListening(SensorSpeed sensorSpeed = SensorSpeed.Default)
    {
        if (!Accelerometer.Default.IsSupported) throw new FeatureNotSupportedException("Shake Detector is Not Supported in Your Device");
        if (Accelerometer.Default.IsMonitoring) throw new InvalidOperationException("Shake Detector is Already Started");

        Accelerometer.Default.Start(sensorSpeed);
        useSyncContext = sensorSpeed == SensorSpeed.Default || sensorSpeed == SensorSpeed.UI;

        Accelerometer.Default.ReadingChanged += Accelerometer_ReadingChanged;
    }

    private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
        float y = e.Reading.Acceleration.Y;
        float x = e.Reading.Acceleration.X;
        float z = e.Reading.Acceleration.Z;

        double gForce = Math.Sqrt(x * x + y * y + z * z);

        if (gForce > ShakeThresholdGravity)
        {
            TimeSpan now = new(DateTime.Now.Ticks);

            if (currentShakeTimeInMilliseconds + ShakeIntervalInMilliseconds > now) return;

            if (currentShakeTimeInMilliseconds + ShakeResetIntervalInMilliseconds < now) currentShakeCount = 0;

            currentShakeTimeInMilliseconds = now;
            currentShakeCount++;

            if (currentShakeCount < MinimumShakeCount) return;

            if (IsHapticsEnabled)
            {
                if (!IsHapticsSupported) throw new FeatureNotSupportedException("Haptics is Not Supported in Your Device");
                Vibration.Default.Vibrate(HapticsDurationInMilliseconds);
            }

            if (useSyncContext)
            {
                MainThread.BeginInvokeOnMainThread(() => ShakeDetected?.Invoke(this, new ShakeDetectedEventArgs(currentShakeCount)));
                return;
            }
            ShakeDetected?.Invoke(this, new ShakeDetectedEventArgs(currentShakeCount));
        }
    }

    public void StopListening()
    {
        if (Accelerometer.Default.IsMonitoring)
        {
            Accelerometer.Default.ReadingChanged -= Accelerometer_ReadingChanged;
            Accelerometer.Default.Stop();
        }
    }
}
