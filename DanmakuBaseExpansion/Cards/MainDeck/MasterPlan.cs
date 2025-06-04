using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class MasterPlan : SingleModeBaseMainCard, IActionMainTiming {
        public MasterPlan(int id, ISeason season) : base(id,
            "Master Plan",
            season,
            3,
            new ActionMasterPlan()) { }
    }
}