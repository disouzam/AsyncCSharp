using System;
using System.Threading.Tasks;

namespace Async2
{
  class Program
  {
    static async Task Main(string[] args)
    {
      // Correct execution
      Console.WriteLine("1. Correct execution");

      await AsyncMethod.CorrectMethod();

      Console.WriteLine("\t4. Before delay in main program...");
      int delay = 15000;
      await Task.Delay(delay);
      Console.WriteLine("\t5. After delay in main program...");

      Console.WriteLine("6. CorrectMethod just finished!");

      Console.WriteLine();
      Console.WriteLine();

      // Wrong execution
      Console.WriteLine("1. Wrong execution");

      AsyncMethod.WrongMethod();

      Console.WriteLine("\t4. Before delay in main program...");
      delay = 5000;
      await Task.Delay(delay);
      Console.WriteLine("\t5. After delay in main program...");

      Console.WriteLine("6. WrongMethod just finished!");

      Console.WriteLine();
      Console.WriteLine();

      // Second way of Wrong execution
      Console.WriteLine("1. Second way of Wrong execution");

      AsyncMethod.WrongMethod();

      Console.WriteLine("\t4. Before delay in main program...");
      delay = 80000;
      await Task.Delay(delay);
      Console.WriteLine("\t5. After delay in main program...");

      Console.WriteLine("6. WrongMethod just finished!");
    }
  }
}
