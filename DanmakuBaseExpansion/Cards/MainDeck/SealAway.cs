using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Power : BaseMainCard {
        public Power(string id, ISeason season) : base(id,
            "Power",
            season,
            2) { }
    }
}