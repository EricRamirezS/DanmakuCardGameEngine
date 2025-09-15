using System;
using DanmakuBaseExpansion.Cards.CharacterDeck;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    /// <summary>
    /// Represents the "Bomb" card from the Main deck.
    /// </summary>
    /// <remarks>
    /// <para><b>Card Name:</b> Bomb</para>
    /// <para><b>Deck:</b> Main deck</para>
    /// <para><b>Point Value:</b> 4</para>
    /// <para><b>Card Types:</b>  <see cref="DanmakuCardGameEngine.Enums.CardSubtypes.Invocation"/> / <see cref="DanmakuCardGameEngine.Enums.CardTimings.Reaction"/></para>
    /// <para><b>Text:</b></para>
    /// <para>Activate your Spell Card. You can only activate one Spell Card per round.</para>
    /// <para>Or, play this when another player plays a Danmaku card or activates their Spell Card. Cancel that card.</para>
    /// <para><b>Card FAQ and Errata:</b></para>
    /// <list type="bullet">
    /// <item>You can use a Bomb to cancel a Spell Card regardless of what method was used to activate it.</item>
    /// <item>The second option is independent of your limit on playing one Spell Card per round. 
    /// You may use a Bomb to cancel a Spell Card during a round in which you have already activated your own Spell Card, and vice versa.</item>
    /// <item>If a player plays a Bomb card using the second option to cancel a Danmaku or Spell Card, you cannot use another Bomb to cancel that Bomb.</item>
    /// <item>If a player uses a Spell Card (such as <see cref="KamishirasawaKeine"/>'s “Phantasmal Emperor”) to cancel another player's card or Spell Card, 
    /// you may cancel that Spell Card with Bomb. In this case, the original Spell Card is no longer cancelled. 
    /// If no other player cancels the original Spell Card, it resolves like normal.</item>
    /// </list>
    /// </remarks>
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