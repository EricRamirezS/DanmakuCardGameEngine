using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    /// <summary>
    /// <b>Capture Spell Card</b><br/>
    /// <b>Deck:</b> Main deck<br/>
    /// <b>Point value:</b> 4<br/>
    /// <b>Card types:</b> <see cref="DanmakuCardGameEngine.Enums.CardSubtypes.Invocation"/>
    /// </summary>
    /// <remarks>
    /// <b>Effect:</b> Choose another player and activate their character’s Spell Card as if it were your own. You may choose a defeated player’s character.<br/>
    /// You can only activate one Spell Card per round.
    /// 
    /// <para><b>Card FAQ and errata:</b></para>
    /// <list type="bullet">
    /// <item>The timing of Capture Spell Card depends on the Spell Card you are activating. If the chosen Spell Card is an Action, it can only be used during your main step. If it is a Reaction, it can only be activated when the condition described in the Spell Card text is true for you.</item>
    /// <item>Activating another player’s Spell Card counts toward the one Spell Card per round limit.</item>
    /// </list>
    /// </remarks>
    [Serializable]
    public class CaptureSpellCard : SingleModeBaseMainCard, IInvocationMainTiming {
        public CaptureSpellCard(int id, ISeason season) : base(
            id,
            "Capture Spell Card",
            season,
            4,
            new InvocationCaptureSpellCard()) { }
    }
}