using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class SealAway : SingleModeBaseMainCard, IActionMainTiming {
        public SealAway(int id, ISeason season) : base(id,
            "Seal Away",
            season,
            2,
            new ActionSealAway()) { }
    }
}