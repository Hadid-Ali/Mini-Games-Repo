namespace Infrastructure.GameEvents
{
    public static partial class GameEvents
    {
        public static class GameSetupEvents
        {
            public static GameEvent<GameMode> GameModeSelected = new();
            public static GameEvent<SoccerPlayer> SoccerPlayerSpawned = new();
            public static GameEvent<SoccerBall> SoccerBallSpawned = new();
            public static GameEvent<GameModeMetaData> GameModeInitialized = new();
        }
    }
}