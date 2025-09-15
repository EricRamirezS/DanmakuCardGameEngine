using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    /// <summary>
    /// <b>Graze</b><br/>
    /// <b>Deck:</b> Main deck<br/>
    /// <b>Point value:</b> 1<br/>
    /// <b>Card Types:</b> <see cref="DanmakuCardGameEngine.Enums.CardTimings.Reaction"/>, <see cref="DanmakuCardGameEngine.Enums.CardSubtypes.Dodge"/>
    /// </summary>
    /// <remarks>
    /// Play this when you are attacked.<br/>
    /// You avoid the attack.<br/>
    /// You may discard a card to play this on behalf of another player.<br/>
    /// <b>Card FAQ and errata:</b><br/>
    /// <see cref="DanmakuCardGameEngine.Enums.CardSubtypes.Danmaku"/> cards discarded to play Graze on behalf of other players do not count toward your <see cref="DanmakuCardGameEngine.Enums.CardSubtypes.Danmaku"/> card limit.
    /// </remarks>
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