using System;

namespace SyncBreakfast
{
  internal class Timer
  {
    private DateTime startTime;

    private DateTime endTime;

    private bool taskEnded = false;

    private string _taskName;

    private Guid GUID;

    public Timer(string taskName)
    {
      _taskName = taskName;
      startTime = DateTime.Now;
      GUID = Guid.NewGuid();
    
      Console.WriteLine($"{Environment.NewLine}START:  Task {GUID} - {_taskName}{Environment.NewLine}");
    }

    public void recordEndTime()
    {
      endTime = DateTime.Now;
      taskEnded = true;
    }

    public TimeSpan timeSpent()
    {
      if (taskEnded)
      {
        return (TimeSpan)(endTime - startTime);
      }else
      {
        throw new InvalidOperationException("Can't calculate timeSpent before a task has ended");
      }
    }

    public override string ToString()
    {
      if (taskEnded)
      {
        return $"{Environment.NewLine}FINISH: Task {GUID} - {_taskName} took {timeSpent().ToString()} to finish.{Environment.NewLine}";
      }else
      {
        return $"{Environment.NewLine}ERROR - Task {GUID} - {_taskName} - has not finished yet.{Environment.NewLine}";
      }
    }
  }
}