using System;
using System.Threading.Tasks;

namespace Async2
{
  class Program
  {
    static async Task Main(string[] args)
    {
      Console.WriteLine("Main Program has started!");

      await AsyncMethod1.Method1();

      Console.WriteLine("\tBefore delay in main program...");
      int delay = 15000;
      await Task.Delay(delay);
      Console.WriteLine("\tAfter delay in main program...");

      Console.WriteLine("Main Program just finished!");
    }
  }
}
