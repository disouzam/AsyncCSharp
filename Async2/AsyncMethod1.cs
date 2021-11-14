using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async2
{
  internal class AsyncMethod1
  {
    public static async Task Method1()
    {
      DateTime startTime;
      int delay = 15000;
      Console.WriteLine($"Method 1 has started! - {startTime = DateTime.Now}");
      
      await Task.Delay(delay);

      DateTime endTime;
      Console.WriteLine($"Method 1 finished - Just have finished at {endTime = startTime.AddMilliseconds(delay)}! - {((DateTime.Now < endTime) ? "Wrong Early execution" : "Correct execution.")}");
    }
  }
}