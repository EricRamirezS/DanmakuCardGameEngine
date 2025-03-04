using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class KonpakuYoumu : BaseCharacterCard {
        public KonpakuYoumu() : base(15, "Konpaku Youmu", Seasons.Spring) { }
        public override ISpellCardTiming SpellCardTiming { get; }
    }
}