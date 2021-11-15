using System;
using System.Threading.Tasks;

namespace SixTipsAsync
{
  class Program
  {
    static async Task Main(string[] args)
    {
      // Tip1_AsyncVoid.Run();
      // await Tip2_ThreadsDataBinding.RunDataBoundTask(); 
      await Tip2_ThreadsDataBinding.RunCPUBoundTask();
    }
  }
}
