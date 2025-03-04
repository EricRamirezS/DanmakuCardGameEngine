using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Kourindou : SingleModeMainCard, IActionMainMode {
        public Kourindou(int id, ISeason season) : base(id,
            "Kourindou",
            season,
            3,
            new ActionKourindou()) { }
    }
}