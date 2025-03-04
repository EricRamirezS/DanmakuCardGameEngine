using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Voile : SingleModeMainCard, IActionMainMode {
        public Voile(int id, ISeason season) : base(id,
            "Voile",
            season,
            5,
            new ActionVoile()) { }
    }
}