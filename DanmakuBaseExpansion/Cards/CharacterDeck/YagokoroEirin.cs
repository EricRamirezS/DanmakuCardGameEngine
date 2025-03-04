using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class YagokoroEirin : BaseCharacterCard {
        public YagokoroEirin() : base(23, "Yagokoro Eirin", Seasons.Spring) { }
        public override ISpellCardTiming SpellCardTiming { get; }
    }
}