using System;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine($"{DateTime.Now} - Coffee is ready");

            Egg eggs = await FryEggsAsync(2);
            Console.WriteLine($"{DateTime.Now} - Eggs are ready");

            Bacon bacon = await FryBaconAsync(3);
            Console.WriteLine($"{DateTime.Now} - Bacon is ready");

            Toast toast = await ToastBreadAsync(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine($"{DateTime.Now} - Toast is ready");

            Juice OrangeJuice = PourOrangeJuice();
            Console.WriteLine($"{DateTime.Now} - Orange juice is ready");
            Console.WriteLine($"{DateTime.Now} - Breakfast is ready!");
        }

        private static Juice PourOrangeJuice()
        {
            Console.WriteLine($"{DateTime.Now} - Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine($"{DateTime.Now} - Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine($"{DateTime.Now} - Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine($"{DateTime.Now} - Putting a slice of bread in the toaster");
            }
            Console.WriteLine($"{DateTime.Now} - Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine($"{DateTime.Now} - Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"{DateTime.Now} - Putting {slices} slices of bacon in the pan");
            Console.WriteLine($"{DateTime.Now} - Cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine($"{DateTime.Now} - Flipping a slice of bacon");
            }
            Console.WriteLine($"{DateTime.Now} - Cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine($"{DateTime.Now} - Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine($"{DateTime.Now} - Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"{DateTime.Now} - Cracking {howMany} eggs");
            Console.WriteLine($"{DateTime.Now} - Cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine($"{DateTime.Now} - Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine($"{DateTime.Now} - Pouring coffee");
            return new Coffee();
        }
    }
}