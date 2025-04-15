namespace Infrastructure.GameEvents
{
    public static partial class GameEvents
    {
        public static class GameplayEvents
        {
            public static GameEvent<SoccerPlayer, bool> SoccerPlayerSelected = new();
            public static GameEvent RoundStarted = new();
        }
    }
}