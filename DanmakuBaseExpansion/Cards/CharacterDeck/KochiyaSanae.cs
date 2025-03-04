using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class KochiyaSanae : BaseCharacterCard {
        public KochiyaSanae() : base(13, "Kochiya Sanae", Seasons.Autumn) { }
        public override ISpellCardTiming SpellCardTiming { get; }
    }
}