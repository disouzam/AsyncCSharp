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
      await Task.Delay(5000);
      Console.WriteLine("\tFINISHED: Method1Async");
      return 1;
    }

    public static int Method2()
    {
      Console.WriteLine("Method2");
      Thread.Sleep(10000);
      Console.WriteLine("\tFINISHED: Method2");
      return 1;
    }

    public static async Task<int> Method3Async()
    {
      Console.WriteLine("Method3Async");
      await Task.Delay(15000);
      Console.WriteLine("\tFINISHED: Method3Async");
      return 1;
    }

    public static int Method4()
    {
      Console.WriteLine("Method4");
      Thread.Sleep(20000);
      Console.WriteLine("\tFINISHED: Method4");
      return 1;
    }

    public static async Task<int[]> MethodWrapper()
    {
      Task<int> r2Task = Task.Run(() => MethodCollection.Method2());
      Task<int> r4Task = Task.Run(() => MethodCollection.Method4());

      return await Task.WhenAll(r2Task,r4Task);
    }
  }

}