using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Enums {
    public static class Durations {
        public static readonly IDuration Turn = new Duration("Turn");
        public static readonly IDuration Round = new Duration("Round");
        public static readonly IDuration Active = new Duration("Active");
    }
}