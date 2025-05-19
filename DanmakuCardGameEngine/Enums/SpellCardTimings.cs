using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Enums {
    public static class SpellCardTimings {
        public static readonly ISpellCardTiming Action = new SpellCardTiming("Action");
        public static readonly ISpellCardTiming Reaction = new SpellCardTiming("Reaction");
        public static readonly ISpellCardTiming Copy = new SpellCardTiming("Copy");
    }
}