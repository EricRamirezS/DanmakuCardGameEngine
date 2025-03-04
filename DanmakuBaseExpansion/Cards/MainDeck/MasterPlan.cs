using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class MasterPlan : SingleModeMainCard, IActionMainMode {
        public MasterPlan(int id, ISeason season) : base(id,
            "Master Plan",
            season,
            3,
            new ActionMasterPlan()) { }
    }
}