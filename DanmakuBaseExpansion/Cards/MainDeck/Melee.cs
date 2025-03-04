using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class MasterPlan : BaseMainCard {
        public MasterPlan(string id, ISeason season) : base(id,
            "Master Plan",
            season,
            3) { }
    }
}