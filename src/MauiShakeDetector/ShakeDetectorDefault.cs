namespace MauiShakeDetector;
internal sealed class ShakeDetectorDefault : IShakeDetector
{
    // Properties
    public bool IsSupported { get; set; } = Accelerometer.Default.IsSupported;
    public bool IsMonitoring { get; set; } = Accelerometer.Default.IsMonitoring;
    public double ShakeThresholdGravity { get; set; } = 2.1;
    public TimeSpan ShakeIntervalInMilliseconds { get; set; } = new TimeSpan(500);
    public TimeSpan ShakeCountResetTime { get; set; } = new TimeSpan(3000);
    public int MinimumShakeCount { get; set; } = 1;
    public bool IsHapticsEnabled { get; set; } = true;
    public bool IsHapticsSupported { get; set; } = Vibration.Default.IsSupported;
    public TimeSpan HapticsDurationInMilliseconds { get; set; } = new TimeSpan(3000);


    // Private Fields
    TimeSpan currentShakeTimeInMilliseconds = new(DateTime.Now.Ticks);
    int currentShakeCount = 0;

    public event EventHandler<ShakeDetectedEventArgs> ShakeDetected;

    public void StartListening()
    {
        if (!Accelerometer.Default.IsSupported) throw new FeatureNotSupportedException("Shake Detector is Not Supported in Your Device");
        if (Accelerometer.Default.IsMonitoring) throw new InvalidOperationException("Shake Detector is Already Started");

        Accelerometer.Default.Start(SensorSpeed.Default);

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

            if (currentShakeTimeInMilliseconds + ShakeCountResetTime < now) currentShakeCount = 0;

            currentShakeTimeInMilliseconds = now;
            currentShakeCount++;

            if (currentShakeCount < MinimumShakeCount) return;

            if (IsHapticsEnabled)
            {
                if (!IsHapticsSupported) throw new FeatureNotSupportedException("Haptics is Not Supported in Your Device");
                Vibration.Default.Vibrate(HapticsDurationInMilliseconds);
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
