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

      DateTime expectedEndTime;
      DateTime actualEndTime;
      Console.WriteLine($"Expected end time: {expectedEndTime = startTime.AddMilliseconds(delay)} <> Actual end time: {actualEndTime = DateTime.Now} >>> {((actualEndTime < expectedEndTime) ? "Wrong Early execution" : "Correct execution.")}");
    }
  }
}