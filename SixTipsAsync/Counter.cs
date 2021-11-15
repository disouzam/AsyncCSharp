// Code from https://docs.microsoft.com/en-us/dotnet/standard/events/how-to-raise-and-consume-events
using System;

class Counter
{
  private int threshold;

  private int total;

  public Counter(int passedThreshold)
  {
    threshold = passedThreshold;
    Console.WriteLine($"Threshold was set to be: {threshold}");
  }

  public int Total() => total;

  public int Threshold() => threshold;

  public void Add(int x)
  {
    total += x;
    if (total >= threshold)
    {
      ThresholdReached?.Invoke(this, EventArgs.Empty);
    }
  }

  public event EventHandler ThresholdReached;
}