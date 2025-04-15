using System;

namespace Infrastructure.GameEvents
{
  public static partial class GameEvents
  {
    public static class JobEvents
    {
      public static readonly GameEvent<JobMetaData> ScheduleJob = new();
      public static readonly GameEvent<Guid> TerminateJob = new();
    }
  }
}
