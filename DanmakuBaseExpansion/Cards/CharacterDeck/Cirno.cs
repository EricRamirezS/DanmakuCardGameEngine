using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class Cirno : BaseCharacterCard {
        public Cirno() : base(2, "Cirno", Seasons.Winter) { }
        public override ISpellCardTiming SpellCardTiming { get; }
    }
}