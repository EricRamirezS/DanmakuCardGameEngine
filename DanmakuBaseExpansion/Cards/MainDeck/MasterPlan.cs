using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    /// <summary>
    /// <b>Card Name:</b> Master Plan<br/>
    /// <b>Deck:</b> Main deck<br/>
    /// <b>Point Value:</b> 3<br/>
    /// <para><b>Card Types:</b> <see cref="DanmakuCardGameEngine.Enums.CardTimings.Action"/></para>
    /// <b>Text:</b><br/>
    /// Resolve the current incident.<br/><br/>
    /// Then, look at the top three cards of any deck and place them on the top or bottom of that deck in any order.
    /// </summary>
    [Serializable]
    public class MasterPlan : SingleModeBaseMainCard, IActionMainTiming {
        public MasterPlan(int id, ISeason season) : base(id,
            "Master Plan",
            season,
            3,
            new ActionMasterPlan()) { }
    }
}