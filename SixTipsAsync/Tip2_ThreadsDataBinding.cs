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
      int length = new Random().Next(1, 10);

      #region Correct implementation
      Console.WriteLine("Correct implementation");
      start = DateTime.Now;

      List<Task> taskList = new List<Task>();

      for (int i = 0; i < length; i++)
      {
        taskList.Add(SomeDataBoundAsync(i));
      }

      await Task.WhenAll(taskList);

      end = DateTime.Now;
      Console.WriteLine($"Run for {end - start} - Average of {(end - start) / length}");
      #endregion

      #region Wrong implementation
      Console.WriteLine("\n\nWrong implementation");
      start = DateTime.Now;

      for (int i = 0; i < length; i++)
      {
        await SomeDataBoundAsync(i);
      }

      end = DateTime.Now;
      Console.WriteLine($"Run for {end - start} - Average of {(end - start) / length}");
      #endregion

      Console.WriteLine("FINISH Tip 2: Threads and databinding");

    }

    private static async Task SomeDataBoundAsync(int id)
    {
      Guid _GUID = Guid.NewGuid();
      Console.WriteLine($"\t{id} - {_GUID} - Started.");
      await Task.Delay(10000);
      Console.WriteLine($"\t{id} - {_GUID} - Finished.");
    }
  }
}