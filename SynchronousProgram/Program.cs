using System;
using System.Threading.Tasks;

namespace SyncBreakfast
{
  class Program
  {
    static void Main(string[] args)
    {
      Timer _Timer = new Timer("Main");

      Coffee cup = PourCoffee();
      Console.WriteLine("\tCoffee is ready");

      Timer FryEggs_Timer = new Timer("Frying eggs task");
      Egg eggs = FryEggs(2);
      Console.WriteLine("\tEggs are ready");
      FryEggs_Timer.recordEndTime();
      Console.WriteLine(FryEggs_Timer.ToString());

      Timer FryBacon_Timer = new Timer("Frying bacon task");
      Bacon bacon = FryBacon(3);
      Console.WriteLine("\tBacon is ready");
      FryBacon_Timer.recordEndTime();
      Console.WriteLine(FryBacon_Timer.ToString());

      Timer ToastBread_Timer = new Timer("Toasting task");
      Toast toast = ToastBread(2);
      ApplyButter(toast);
      ApplyJam(toast);
      Console.WriteLine("\tToast is ready");
      ToastBread_Timer.recordEndTime();
      Console.WriteLine(ToastBread_Timer.ToString());

      Juice OrangeJuice = PourOrangeJuice();
      Console.WriteLine("\tOrange juice is ready");
      Console.WriteLine("\tBreakfast is ready!");

      _Timer.recordEndTime();
      Console.WriteLine(_Timer.ToString());
    }

    private static Juice PourOrangeJuice()
    {
      Timer _Timer = new Timer("Pouring orange juice");

      _Timer.recordEndTime();
      Console.WriteLine(_Timer.ToString());
      return new Juice();
    }

    private static void ApplyJam(Toast toast)
    {
      Timer _Timer = new Timer("Putting jam on the toast");

      _Timer.recordEndTime();
      Console.WriteLine(_Timer.ToString());
    }

    private static void ApplyButter(Toast toast)
    {
      Timer _Timer = new Timer("Putting butter on the toast");

      _Timer.recordEndTime();
      Console.WriteLine(_Timer.ToString());
    }

    private static Toast ToastBread(int slices)
    {
      if (slices != 0)
      {
        for (int slice = 0; slice < slices; slice++)
        {
          Console.WriteLine("\tPutting a slice of bread in the toaster");
        }
        Console.WriteLine("\tStart toasting...");
        Task.Delay(60000).Wait();
        Console.WriteLine("\tRemove toast from toaster");
      }

      return new Toast();
    }

    private static Bacon FryBacon(int slices)
    {
      if (slices != 0)
      {
        Console.WriteLine($"\tPutting {slices} slices of bacon in the pan");
        Console.WriteLine("\tCooking first side of bacon...");
        Task.Delay(60000).Wait();
        for (int slice = 0; slice < slices; slice++)
        {
          Console.WriteLine("\tFlipping a slice of bacon");
        }
        Console.WriteLine("\tCooking the second side of bacon...");
        Task.Delay(60000).Wait();
        Console.WriteLine("\tPut bacon on plate");
      }

      return new Bacon();
    }

    private static Egg FryEggs(int howMany)
    {
      if (howMany != 0)
      {
        Console.WriteLine("\tWarming the egg pan...");
        Task.Delay(60000).Wait();
        Console.WriteLine($"\tCracking {howMany} eggs");
        Console.WriteLine("\tCooking the eggs ...");
        Task.Delay(60000).Wait();
        Console.WriteLine("\tPut eggs on plate");
      }

      return new Egg();
    }

    private static Coffee PourCoffee()
    {
      Timer _Timer = new Timer("Pouring coffee");

      _Timer.recordEndTime();
      Console.WriteLine(_Timer.ToString());
      return new Coffee();
    }
  }
}