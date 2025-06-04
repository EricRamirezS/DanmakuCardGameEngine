using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class LastWord : SingleModeBaseMainCard, IActionMainTiming {
        public LastWord(int id, ISeason season) : base(id,
            "Last Word",
            season,
            3,
            new ActionLastWord()) { }
    }
}