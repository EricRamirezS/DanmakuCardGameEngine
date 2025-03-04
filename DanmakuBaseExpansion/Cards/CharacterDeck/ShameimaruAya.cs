using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class ShameimaruAya : BaseCharacterCard {
        public ShameimaruAya() : base(21, "Shameimaru Aya", Seasons.Autumn) { }
        public override ISpellCardTiming SpellCardTiming { get; }
    }
}