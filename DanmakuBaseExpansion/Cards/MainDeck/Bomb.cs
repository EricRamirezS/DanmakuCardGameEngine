using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Bomb : DoubleModeBaseMainCard, IInvocationMainTiming, IReactionAltTiming {
        public Bomb(int id, ISeason season) : base(
            id,
            "Bomb",
            season,
            4,
            new InvocationBomb(),
            new ReactionBomb()) { }
    }
}