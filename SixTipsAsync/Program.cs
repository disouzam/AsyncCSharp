using System;
using System.Threading.Tasks;

namespace SixTipsAsync
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Tip1: Async void is only for event handlers.");

      Counter c = new Counter(new Random().Next(20));
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
      await InternalWrapperAsync();
    }

    private static async Task InternalWrapperAsync()
    {
      try
      {
        Console.WriteLine("The threshold was reached.");
        string message = await Some3rdPartyTaskAsync();
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

    private static async Task<string> Some3rdPartyTaskAsync()
    {
      Console.WriteLine("Some3rdPartyTaskAsync was called.");
      string message = "This is the response from Some3rdPartyTaskAsync.";
      await Task.Delay(1000);
      throw new Exception("Some3rdPartyTaskAsync has exception.");
      Console.WriteLine("Some3rdPartyTaskAsync finished.");
      return message;
    }
  }
}
