using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Voile : SingleModeBaseMainCard, IActionMainTiming {
        public Voile(int id, ISeason season) : base(id,
            "Voile",
            season,
            5,
            new ActionVoile()) { }
    }
}