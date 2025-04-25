namespace Infrastructure.GameEvents
{
    public static partial class GameEvents
    {
        public static  class MenuEvents
        {
            public static readonly GameEvent<MenuName> MenuTransition = new();
        }   
    }
}
