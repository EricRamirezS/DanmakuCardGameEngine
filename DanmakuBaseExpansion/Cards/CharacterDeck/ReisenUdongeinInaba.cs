using DanmakuBaseExpansion.Cards.CharacterDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.CharacterDeck {
    public class ReisenUdongeinInaba : BaseCharacterCard {
        public ReisenUdongeinInaba() : base(18, "Reisen Udongein Inaba", Seasons.Autumn) { }
        public override ICardTiming CardTiming { get; }
    }
}