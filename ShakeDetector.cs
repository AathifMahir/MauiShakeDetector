namespace MauiShake;
public sealed class ShakeDetector : IShakeDetector
{
    public bool IsSupported { get; set; } = false;
    public bool IsMonitoring { get; set; } = false;
    public double ShakeThresholdGravity { get; set; } = 2.7;
    public int ShakeSlopTimeMilliseconds { get; set; } = 500;
    public int ShakeCountResetTime { get; set; } = 3000;
    public int MinimumShakeCount { get; set; } = 1;

    const double gravity = 9.80665;

    int currentShakeTimestamp = DateTime.Now.Millisecond;
    int currentShakeCount = 0;

    public event IShakeDetector.ShakeDetectedEvent ShakeDetected;

    public void StartListening()
    {
        if (!Accelerometer.Default.IsSupported) return;

        Accelerometer.Default.ReadingChanged += Accelerometer_ReadingChanged;
        
    }

    private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
        float y = e.Reading.Acceleration.Y;
        float x = e.Reading.Acceleration.X;
        float z = e.Reading.Acceleration.Z;

        double gY = y / gravity;
        double gX = x / gravity;
        double gZ = z / gravity;

        double gForce = Math.Sqrt(gX * gX + gY * gY + gZ * gZ);

        if(gForce > ShakeThresholdGravity)
        {
            var now = DateTime.Now.Millisecond;

            if (currentShakeTimestamp + ShakeSlopTimeMilliseconds > now) return;

            if (currentShakeTimestamp + ShakeCountResetTime < now) currentShakeCount = 0;

            currentShakeTimestamp = now;
            currentShakeCount++;

            if (currentShakeCount >= MinimumShakeCount) ShakeDetected?.Invoke(this, e);
        }
    }

    public void StopListening()
    {
        if (!Accelerometer.Default.IsSupported) return;

        if (Accelerometer.Default.IsMonitoring)
        {
            Accelerometer.Default.ReadingChanged -= Accelerometer_ReadingChanged;
            Accelerometer.Default.Stop();
        }
    }
}
