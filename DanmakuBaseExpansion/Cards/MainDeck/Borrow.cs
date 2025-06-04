using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Borrow : SingleModeBaseMainCard, IActionMainTiming {
        public Borrow(int id, ISeason season) : base(
            id,
            "\"Borrow\"",
            season,
            2,
            new ActionBorrow()) { }
    }
}