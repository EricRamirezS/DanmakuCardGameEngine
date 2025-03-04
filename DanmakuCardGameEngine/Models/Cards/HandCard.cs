using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    public class HandCard : Card, IHandCard {
        public HandCard(ICardType cardType, string id, string name, ISeason season, IExpansion expansion,
            int pointValue) : base(
            cardType, id, name, season, expansion) {
            PointValue = pointValue;
        }

        public int PointValue { get; }
    }
}