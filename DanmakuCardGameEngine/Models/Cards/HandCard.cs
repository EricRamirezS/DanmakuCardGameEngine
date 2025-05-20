using System;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    public abstract class HandCard : Card, IHandCard {
        protected HandCard(ICardType cardType, int id, string name, ISeason season, IExpansion expansion,
            int pointValue) : base(
            cardType, id, name, season, expansion) {
            PointValue = pointValue;
        }

        public int PointValue { get; }
        public abstract CardMode CardMode { get; }

        public bool CanBePlayed() {
            switch (CardMode) {
                case CardMode.Single:
                    return CanPlayMainMode();
                case CardMode.Double:
                    bool a = CanPlayMainMode();
                    bool b = CanPlayAltMode();
                    return a || b;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public abstract bool CanPlayMainMode();

        public abstract bool CanPlayAltMode();
    }
}