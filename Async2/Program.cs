using System;
using System.Threading.Tasks;

namespace Async2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Main Program has started!");
            
            await AsyncMethod1.Method1();

            Console.WriteLine("Main Program just finished!");
        }
    }
}
