using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Enums {
    public static class Seasons {
        public static readonly ISeason Winter = new Season("Winter");
        public static readonly ISeason Summer = new Season("Summer");
        public static readonly ISeason Autumn = new Season("Autumn");
        public static readonly ISeason Spring = new Season("Spring");
    }
}