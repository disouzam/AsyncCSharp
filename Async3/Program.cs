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
      int ret1 = 0;
      ret1 = await MethodCollection.Method1Async();

      // Call a sync method that doesn't depend on the first async
      int ret2 = 0;
      ret2 = MethodCollection.Method2();

      // Call a second async method
      int ret3 = 0;
      ret3 = await MethodCollection.Method3Async();

      // Call a second sync method that doesn't depend on the first async
      int ret4 = 0;
      ret4 = MethodCollection.Method4();

      // Wait for two async methods be complete
      // Consolidate the result in one single output
      var result = (ret2 + ret4) / (ret1 * ret4);
      Console.WriteLine($"Result: {result}");

      // Print a console statement
      Console.WriteLine("\nTerminating the execution of Async3 program...\n");

      DateTime endTime = DateTime.Now;
      Console.WriteLine($"Elapsed time: {endTime - startTime}");
    }
  }
}
