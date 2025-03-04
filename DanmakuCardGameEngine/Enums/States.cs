using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Enums {
    public static class GameStates {
        public static readonly IState InitialSetup = new State("Initial Setup");
        public static readonly IState SetUpDecks = new State("Initial Setup");
        public static readonly IState DetermineRoles = new State("Initial Setup");
        public static readonly IState AssignCharacter = new State("Initial Setup");
        public static readonly IState InitializeStats = new State("Initial Setup");
        public static readonly IState StartOfThe = new State("Initial Setup");
        public static readonly IState TurnZero = new State("Initial Setup");
        public static readonly IState StartOfTurn = new State("Initial Setup");
        public static readonly IState Incident = new State("Initial Setup");
        public static readonly IState Draw = new State("Initial Setup");
        public static readonly IState Main = new State("Initial Setup");
        public static readonly IState Discard = new State("Initial Setup");
    }
}