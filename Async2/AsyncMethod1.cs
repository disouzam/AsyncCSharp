using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async2
{
  internal class AsyncMethod1
  {
    public static async Task Method1()
    {
      Console.WriteLine("Method 1 has started!");
      Task.Delay(15000);
      Console.WriteLine("Method 1 finished!");
    }
  }
}