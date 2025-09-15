using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Enums {
    public static class CardSubtypes {
        public static readonly ICardSubtype Healing = new CardSubtype("Healing");
        public static readonly ICardSubtype Invocation = new CardSubtype("Invocation");
        public static readonly ICardSubtype Defense = new CardSubtype("Defense");
        public static readonly ICardSubtype Dodge = new CardSubtype("Dodge");
        public static readonly ICardSubtype Danmaku = new CardSubtype("Danmaku");
        public static readonly ICardSubtype Artifact = new CardSubtype("Artifact");
        public static readonly ICardSubtype Power = new CardSubtype("Power");
    }
}