using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async2
{
  internal class AsyncMethod
  {
    public static async Task CorrectMethod()
    {
      DateTime startTime;
      int delay = 60000;
      Console.WriteLine($"2. CorrectMethod has started! - {startTime = DateTime.Now}");
      
      await Task.Delay(delay);

      DateTime expectedEndTime;
      DateTime actualEndTime;
      Console.WriteLine($"3. Expected end time: {expectedEndTime = startTime.AddMilliseconds(delay)} <> Actual end time: {actualEndTime = DateTime.Now} >>> {((actualEndTime < expectedEndTime) ? "Wrong Early execution" : "Correct execution.")}");
    }

    public static async Task WrongMethod()
    {
      DateTime startTime;
      int delay = 60000;
      Console.WriteLine($"2. WrongMethod has started! - {startTime = DateTime.Now}");
      
      await Task.Delay(delay);

      DateTime expectedEndTime;
      DateTime actualEndTime;
      Console.WriteLine($"3. Expected end time: {expectedEndTime = startTime.AddMilliseconds(delay)} <> Actual end time: {actualEndTime = DateTime.Now} >>> {((actualEndTime < expectedEndTime) ? "Wrong Early execution" : "Correct execution.")}");
    }
  }
}