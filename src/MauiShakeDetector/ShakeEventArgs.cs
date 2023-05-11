namespace MauiShakeDetector;
public class ShakeDetectedEventArgs : EventArgs
{
    public ShakeDetectedEventArgs(int noOfShake) => NoOfShakes = noOfShake;
    public int NoOfShakes { get; private set; }
}
