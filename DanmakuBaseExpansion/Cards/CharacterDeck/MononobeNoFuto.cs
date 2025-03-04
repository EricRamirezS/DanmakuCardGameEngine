using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class MononobeNoFuto : BaseCharacterCard {
        public MononobeNoFuto() : base(16, "Mononobe No Futo", Seasons.Winter) { }
        public override ISpellCardTiming SpellCardTiming { get; }
    }
}