namespace MauiShake;
public interface IShakeDetector
{
    public bool IsSupported { get; set; }
    public bool IsMonitoring { get; set; }
    public double ShakeThresholdGravity { get;  set; }
    public int ShakeSlopTimeMilliseconds { get;  set; }
    public int ShakeCountResetTime { get;  set; }
    public int MinimumShakeCount { get;  set; }

    public delegate void ShakeDetectedEvent(object sender, EventArgs e);

    public event ShakeDetectedEvent ShakeDetected;
    void StartListening();
    void StopListening();
}
