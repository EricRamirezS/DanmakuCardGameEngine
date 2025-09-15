using DanmakuBaseExpansion.Cards.CharacterDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class HakureiReimu : BaseCharacterCard {
        public HakureiReimu() : base(3, "Hakurei Reimu", Seasons.Spring) { }
        public override ICardTiming CardTiming { get; }
    }
}