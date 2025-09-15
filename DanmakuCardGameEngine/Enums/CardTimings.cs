using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Enums {
    public static class CardTimings {
        public static readonly ICardTiming Action = new CardTiming("Action");
        public static readonly ICardTiming Reaction = new CardTiming("Reaction");
        public static readonly ICardTiming Instant = new CardTiming("Instant");
        public static readonly ICardTiming Copy = new CardTiming("Copy");
    }
}