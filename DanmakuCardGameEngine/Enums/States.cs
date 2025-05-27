using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Enums {
    public static class States {
        public static readonly IState None = new State("None");
        public static readonly IState InitialSetup = new State("Initial Setup");
        public static readonly IState SetUpDecks = new State("Set Up Decks");
        public static readonly IState DetermineRoles = new State("Determine Roles");
        public static readonly IState AssignCharacter = new State("Assign Character");
        public static readonly IState DealInitialHand = new State("Deal Initial Hand");
        public static readonly IState InitializeStats = new State("Initialize Stats");
        public static readonly IState StartOfTheGame = new State("Start of The Game");
        public static readonly IState TurnZero = new State("Turn Zero");
        public static readonly IState StartOfTurn = new State("Start Of Turn");
        public static readonly IState Incident = new State("Incident");
        public static readonly IState Draw = new State("Draw");
        public static readonly IState Main = new State("Main");
        public static readonly IState Discard = new State("Discard");
        public static readonly IState EndOfTurn = new State("End of Turn");
        public static readonly IState SkipTurn = new State("Skip Turn");
    }
}