using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Borrow : BaseMainCard {
        public Borrow(string id, ISeason season) : base(
            id,
            "\"Borrow\"",
            season,
            2) { }
    }
}