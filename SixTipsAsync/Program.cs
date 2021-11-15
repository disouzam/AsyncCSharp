using System;

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
        Console.WriteLine("adding one");
        c.Add(1);
      }
    }

    static void c_ThresholdReached(object sender, EventArgs e)
    {
      Console.WriteLine("The threshold was reached.");
      Environment.Exit(0);
    }
  }
}
