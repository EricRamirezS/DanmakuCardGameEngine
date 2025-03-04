using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Enums {
    public static class CardSubtypes {
        public static readonly ICardSubtypes Healing = new Object.CardSubtypes("Healing");
        public static readonly ICardSubtypes Invocation = new Object.CardSubtypes("Invocation");
        public static readonly ICardSubtypes Defense = new Object.CardSubtypes("Defense");
        public static readonly ICardSubtypes Dodge = new Object.CardSubtypes("Dodge");
        public static readonly ICardSubtypes Danmaku = new Object.CardSubtypes("Danmaku");
        public static readonly ICardSubtypes Artifact = new Object.CardSubtypes("Artifact");
        public static readonly ICardSubtypes Power = new Object.CardSubtypes("Power");
    }
}