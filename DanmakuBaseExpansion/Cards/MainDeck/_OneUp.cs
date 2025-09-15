using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    /// <summary>
    /// Represents the "1UP" card from the Main deck.
    /// </summary>
    /// <remarks>
    /// <para><b>Card Name:</b> 1UP</para>
    /// <para><b>Deck:</b> Main deck</para>
    /// <para><b>Point Value:</b> 2</para>
    /// <para><b>Card Types:</b> <see cref="DanmakuCardGameEngine.Enums.CardSubtypes.Healing"/>, <see cref="DanmakuCardGameEngine.Enums.CardTimings.Action"/> /  <see cref="DanmakuCardGameEngine.Enums.CardSubtypes.Healing"/>, <see cref="DanmakuCardGameEngine.Enums.CardTimings.Reaction"/> </para>
    /// <para><b>Text:</b></para>
    /// <para>Choose a player. That player gains 1 life. You cannot go above your max life.</para>
    /// <para>OR</para>
    /// <para>Play this when any player is reduced to 0 life. That player returns to 1 life.</para>
    /// <para><b>Card FAQ and Errata:</b></para>
    /// <list type="bullet">
    /// <item>Players that are saved from defeat using the second option still draw a card for losing life.</item>
    /// <item><b>Errata:</b> The bottom half of 1UP is <i>healing</i> type.</item>
    /// </list>
    /// </remarks>
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