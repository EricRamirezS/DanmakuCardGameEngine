using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class OneUp : DoubleModeBaseMainCard, IActionMainTiming, IReactionAltTiming {
        public OneUp(int id, ISeason season) : base(
            id,
            "1UP",
            season,
            2,
            new ActionOneUp(), new ReactionOneUp()) { }
    }

}