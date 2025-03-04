using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class KomeijiSatori : BaseCharacterCard {
        public KomeijiSatori() : base(14, "Komeiji Satori", Seasons.Winter) { }
        public override ISpellCardTiming SpellCardTiming { get; }
    }
}