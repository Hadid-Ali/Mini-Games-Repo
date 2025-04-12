namespace Infrastructure.GameEvents
{
    public static partial class GameEvents
    {
        public static class GameplayUIEvents
        {
            public static GameEvent<int, int> ScoreUpdated = new();
            public static GameEvent ComboScored = new();
        }
    }
}