using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Party : SingleModeBaseMainCard, IActionMainTiming {
        public Party(int id, ISeason season) : base(id,
            "Party",
            season,
            3,
            new ActionParty()) { }
    }
}