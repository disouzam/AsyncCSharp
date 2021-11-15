using System;
using System.Threading.Tasks;

namespace Async3
{
  class Program
  {
    static async Task Main(string[] args)
    {
      DateTime startTime = DateTime.Now;

      // Print a console statement
      Console.WriteLine("Starting Async3 program...\n");

      // Call a first async method
      Task<int> ret1Task = MethodCollection.Method1Async();

      // Call a second async method
      Task<int> ret3Task = MethodCollection.Method3Async();

      // Call a sync method that doesn't depend on the first async
      int ret2 = 0;
      // ret2 = MethodCollection.Method2();

      // Call a second sync method that doesn't depend on the first async
      int ret4 = 0;
      // ret4 = MethodCollection.Method4();

      var ret2N4 = await MethodCollection.MethodWrapper();

      // Wait for two async methods be complete
      // Consolidate the result in one single output
      int ret1 = 0;
      ret1 = await ret1Task;

      int ret3 = 0;
      ret3 = await ret3Task;

      ret2 = ret2N4[0];
      ret4 = ret2N4[1];

      var result = (ret2 + ret4) / (ret1 * ret4);
      Console.WriteLine($"Result: {result}");

      // Print a console statement
      Console.WriteLine("\nTerminating the execution of Async3 program...\n");

      DateTime endTime = DateTime.Now;
      Console.WriteLine($"Elapsed time: {endTime - startTime}");
    }
  }
}
