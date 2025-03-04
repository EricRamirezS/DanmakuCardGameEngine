using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Borrow : SingleModeMainCard, IActionMainMode {
        public Borrow(int id, ISeason season) : base(
            id,
            "\"Borrow\"",
            season,
            2,
            new ActionBorrow()) { }
    }
}