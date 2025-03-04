using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Party : SingleModeMainCard, IActionMainMode {
        public Party(int id, ISeason season) : base(id,
            "Party",
            season,
            3,
            new ActionParty()) { }
    }
}