using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
  class Program
  {
    static async Task Main(string[] args)
    {
      Timer _Timer = new Timer("Main");

      Coffee cup = PourCoffee();
      Console.WriteLine("\tCoffee is ready");

      Timer FryEggs_Timer = new Timer("Frying eggs task");
      Task<Egg> eggsTask = FryEggsAsync(2);

      Timer FryBacon_Timer = new Timer("Frying bacon task");
      Task<Bacon> baconTask = FryBaconAsync(3);

      Timer ToastBread_Timer = new Timer("Toasting task");
      Task<Toast> toastTask = MakeToastWithButterAndJamAsync(2);

      Egg eggs = await eggsTask;
      Console.WriteLine("\tEggs are ready");
      FryEggs_Timer.recordEndTime();
      Console.WriteLine(FryEggs_Timer.ToString());

      Bacon bacon = await baconTask;
      Console.WriteLine("\tBacon is ready");
      FryBacon_Timer.recordEndTime();
      Console.WriteLine(FryBacon_Timer.ToString());

      Toast toast = await toastTask;
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

    private static async Task<Toast> ToastBreadAsync(int slices)
    {
      if (slices != 0)
      {
        for (int slice = 0; slice < slices; slice++)
        {
          Console.WriteLine("\tPutting a slice of bread in the toaster");
        }
        Console.WriteLine("\tStart toasting...");
        await Task.Delay(15000);
        Console.WriteLine($"\tRemove toast from toaster - ThreadId:{Thread.CurrentThread.ManagedThreadId}");
      }

      return new Toast();
    }

    private static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
    {
      var toast = await ToastBreadAsync(number);
      ApplyButter(toast);
      ApplyJam(toast);

      return toast;
    }

    private static async Task<Bacon> FryBaconAsync(int slices)
    {
      if (slices != 0)
      {


        Console.WriteLine($"\tPutting {slices} slices of bacon in the pan");
        Console.WriteLine("\tCooking first side of bacon...");
        await Task.Delay(15000);
        for (int slice = 0; slice < slices; slice++)
        {
          Console.WriteLine("\tFlipping a slice of bacon");
        }
        Console.WriteLine("\tCooking the second side of bacon...");
        await Task.Delay(15000);
        Console.WriteLine($"\tPut bacon on plate - ThreadId:{Thread.CurrentThread.ManagedThreadId}");
      }

      return new Bacon();
    }

    private static async Task<Egg> FryEggsAsync(int howMany)
    {
      if (howMany != 0)
      {
        Console.WriteLine("\tWarming the egg pan...");
        await Task.Delay(15000);
        Console.WriteLine($"\tCracking {howMany} eggs");
        Console.WriteLine("\tCooking the eggs ...");
        await Task.Delay(15000);
        Console.WriteLine($"\tPut eggs on plate - ThreadId:{Thread.CurrentThread}");
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