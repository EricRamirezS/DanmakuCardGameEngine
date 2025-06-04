using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Melee : SingleModeBaseMainCard, IActionMainTiming {
        public Melee(int id, ISeason season) : base(id,
            "Melee",
            season,
            2,
            new ActionMelee()) { }
    }
}