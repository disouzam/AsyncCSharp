using System;
using System.Threading.Tasks;

namespace SixTipsAsync
{
  public class Tip1_AsyncVoid
  {
    public static void Run()
    {
      Console.WriteLine("Tip1: Async void is only for event handlers.");

      Counter c = new Counter(new Random().Next(5));
      c.ThresholdReached += c_ThresholdReached;

      Console.WriteLine("press 'a' key to increase total");
      while (Console.ReadKey(true).KeyChar == 'a')
      {
        Console.WriteLine($"{c.Total() + 1}/{c.Threshold()} - adding one");
        c.Add(1);
      }
    }

        static async void c_ThresholdReached(object sender, EventArgs e)
    {
      try
      {
        Console.WriteLine("The threshold was reached.");
        string message = await SomeTaskAsync();
        await Task.Delay(5000);
        Console.WriteLine($"This is the return message: {message}");
      }
      catch (System.Exception ex)
      {
        Console.WriteLine("Error posting data to server. " + ex.Message);
      }
      finally
      {
        Console.WriteLine("Console will be terminated.");
        Environment.Exit(0);
      }

    }

    private static async Task<string> SomeTaskAsync()
    {
      Console.WriteLine("SomeTaskAsync was called.");
      string message = "This is the response from SomeTaskAsync.";
      await Task.Delay(1000);
      // throw new Exception("SomeTaskAsync has exception.");
      Console.WriteLine("SomeTaskAsync finished.");
      return message;
    }
  }
}