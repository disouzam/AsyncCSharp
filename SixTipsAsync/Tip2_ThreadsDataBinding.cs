using System;
using System.Collections.Generic;
using static System.Math;
using System.Threading.Tasks;

namespace SixTipsAsync
{
  public class Tip2_ThreadsDataBinding
  {
    public static async Task RunDataBoundTask()
    {
      Console.WriteLine("START  Tip 2: Threads and databinding");
      DateTime start;
      DateTime end;
      int length = new Random().Next(100, 500);

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
      await Task.Delay(500);
      Console.WriteLine($"\t\t{id}/{total} - {_GUID} - Finished.");
    }

    public static async Task RunCPUBoundTask()
    {
      DateTime start;
      DateTime end;
      start = DateTime.Now;
      var expectedPayoutTask = Task.Run(() => SomeCPUBound());

      DateTime currentTime = DateTime.Now;
      DateTime oldTime = DateTime.Now;
      while (expectedPayoutTask.IsCompleted == false)
      {
        currentTime = DateTime.Now;
        if (currentTime - oldTime > TimeSpan.FromSeconds(60))
        {
          Console.WriteLine($"{DateTime.Now} - Running for {currentTime - start}");
          oldTime = currentTime;
        }
      }

      var expectedPayout = await expectedPayoutTask;

      end = DateTime.Now;

      Console.WriteLine($"Total Payout inside RunCPUBoundTask = {expectedPayout}");
      Console.WriteLine($"Quantitative Finance simulation run for {end - start}");
    }

    private static double SomeCPUBound()
    {
      int iterations = 1000000;
      double[] prices = new double[252];
      double total_payout = 0;
      for (int i = 0; i < iterations; i++)
      {
        prices = SimulateStockPrice(100, 0.2, 0.2);
        total_payout += Payout_AsianCallOption(prices, 110);
        if (i % 100 == 0)
        {
          Console.WriteLine($"i = {i}");
        }
      }
      double expectedPayout = total_payout / iterations;
      Console.WriteLine($"Total Payout inside SomeCPUBound = {expectedPayout}");
      return expectedPayout;
    }

    // Box-Muller technique, generates "standard normal" distribution,(mean = 0,, variance = 1)
    private static double NextNormal()
    {
      var u1 = new Random().NextDouble();
      var u2 = new Random().NextDouble();
      return Sqrt(-2.0 * Log(u1)) * Sin(2.0 * PI * u2);
    }

    // Geometric Brownian Motion, a common technique to model stock price
    private static double[] SimulateStockPrice(double initialPrice,
                                               double drift,
                                               double volatility)
    {
      double[] prices = new double[252];
      var dt = 1.0 / prices.Length;
      int i = 0;
      var nextval = initialPrice;

      while (i + 1 < prices.Length)
      {
        prices[i] = nextval;
        nextval = nextval * (1.0 + drift * dt + volatility * NextNormal() * Sqrt(dt));
        if (nextval < 0.0)
        {
          nextval = 0.0;
        }
        i++;
      }
      return prices;
    }

    // An Asian Call Option gives payout if strike price is lower than average stock price
    private static double Payout_AsianCallOption(double[] prices, double strikePrice)
    {
      double average = 0;
      int length = prices.Length;
      for (int i = 0; i < length; i++)
      {
        average += prices[i];
      }
      average = average / length;
      return Max(average - strikePrice, 0.0);
    }
  }
}