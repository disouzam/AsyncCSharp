using System;
using System.Threading.Tasks;

namespace SyncBreakfast
{
    class Program
    {
        static void Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine($"{DateTime.Now} - Coffee is ready");

            Egg eggs = FryEggs(2);
            Console.WriteLine($"{DateTime.Now} - Eggs are ready");

            Bacon bacon = FryBacon(3);
            Console.WriteLine($"{DateTime.Now} - Bacon is ready");

            Toast toast = ToastBread(2);
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

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine($"{DateTime.Now} - Putting a slice of bread in the toaster");
            }
            Console.WriteLine($"{DateTime.Now} - Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"{DateTime.Now} - Remove toast from toaster");

            return new Toast();
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"{DateTime.Now} - Putting {slices} slices of bacon in the pan");
            Console.WriteLine($"{DateTime.Now} - Cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine($"{DateTime.Now} - flipping a slice of bacon");
            }
            Console.WriteLine($"{DateTime.Now} - Cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"{DateTime.Now} - Put bacon on plate");

            return new Bacon();
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine($"{DateTime.Now} - Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"{DateTime.Now} - Cracking {howMany} eggs");
            Console.WriteLine($"{DateTime.Now} - Cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"{DateTime.Now} - Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine($"{DateTime.Now} - Pouring coffee - ");
            return new Coffee();
        }
    }
}