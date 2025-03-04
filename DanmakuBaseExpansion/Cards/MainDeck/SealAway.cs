using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class SealAway : SingleModeMainCard, IActionMainMode {
        public SealAway(int id, ISeason season) : base(id,
            "Seal Away",
            season,
            2,
            new ActionSealAway()) { }
    }
}