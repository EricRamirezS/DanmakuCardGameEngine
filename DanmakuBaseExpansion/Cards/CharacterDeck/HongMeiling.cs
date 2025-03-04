using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class HongMeiling : BaseCharacterCard {
        public HongMeiling() : base(6, "Hong Meiling", Seasons.Summer) { }
        public override ISpellCardTiming SpellCardTiming { get; }
    }
}