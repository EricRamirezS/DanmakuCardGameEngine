using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Tempest : SingleModeBaseMainCard, IActionMainTiming {
        public Tempest(int id, ISeason season) : base(id,
            "Tempest",
            season,
            3,
            new ActionTempest()) { }
    }
}