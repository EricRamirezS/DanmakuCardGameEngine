using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Graze : DoubleModeBaseMainCard, IReactionMainTiming, IReactionAltTiming {
        public Graze(int id, ISeason season) :
            base(id,
                "Graze",
                season,
                1,
                new ReactionGrazeSelf(),
                new ReactionGrazeOther()) { }
    }
}