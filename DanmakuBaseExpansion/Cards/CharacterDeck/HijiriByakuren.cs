using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class HijiriByakuren : BaseCharacterCard {
        public HijiriByakuren() : base(4, "Hijiri Byakuren", Seasons.Spring) { }
        public override ISpellCardTiming SpellCardTiming { get; }
    }
}