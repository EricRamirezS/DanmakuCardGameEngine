using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Melee : SingleModeMainCard, IActionMainMode {
        public Melee(int id, ISeason season) : base(id,
            "Melee",
            season,
            2,
            new ActionMelee()) { }
    }
}