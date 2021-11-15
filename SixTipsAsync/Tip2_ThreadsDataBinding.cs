using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SixTipsAsync
{
  public class Tip2_ThreadsDataBinding
  {
    public static async Task Run()
    {
      Console.WriteLine("START  Tip 2: Threads and databinding");
      DateTime start;
      DateTime end;
      int length = new Random().Next(100, 1000);

      #region Correct implementation
      Console.WriteLine("Correct implementation");
      start = DateTime.Now;

      List<Task> taskList = new List<Task>();

      for (int i = 0; i < length; i++)
      {
        taskList.Add(SomeDataBoundAsync(i, length));
      }

      await Task.WhenAll(taskList);

      end = DateTime.Now;
      TimeSpan correctImplTime = end - start;
      #endregion

      #region Wrong implementation
      Console.WriteLine("\n\nWrong implementation");
      start = DateTime.Now;

      for (int i = 0; i < length; i++)
      {
        await SomeDataBoundAsync(i, length);
      }

      end = DateTime.Now;
      TimeSpan wrongImplTime = end - start;
      #endregion

      Console.WriteLine($"Correct implementation: Run for {correctImplTime} - Average of {(correctImplTime) / length}");
      Console.WriteLine($"Wrong implementation: Run for {wrongImplTime} - Average of {(wrongImplTime) / length}");
      Console.WriteLine("FINISH Tip 2: Threads and databinding");

    }

    private static async Task SomeDataBoundAsync(int id, int total)
    {
      Guid _GUID = Guid.NewGuid();
      Console.WriteLine($"\t{id}/{total} - {_GUID} - Started.");
      await Task.Delay(100);
      Console.WriteLine($"\t\t{id}/{total} - {_GUID} - Finished.");
    }
  }
}