using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async3
{
  internal class MethodCollection
  {
    public static async Task<int> Method1Async()
    {
      Console.WriteLine("Method1Async");
      await Task.Delay(15000);
      return 1;
    }

    public static int Method2()
    {
      Console.WriteLine("Method2");
      Thread.Sleep(15000);
      return 1;
    }

    public static async Task<int> Method3Async()
    {
      Console.WriteLine("Method3Async");
      await Task.Delay(15000);
      return 1;
    }

    public static int Method4()
    {
      Console.WriteLine("Method4");
      Thread.Sleep(15000);
      return 1;
    }
  }

}