using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    /// <summary>
    /// <b>Kourindou</b><br/>
    /// <b>Title:</b> Antique Shop<br/>
    /// <b>Deck:</b> Main deck<br/>
    /// <b>Point value:</b> 3<br/>
    /// <b>Card Types:</b> <see cref="DanmakuCardGameEngine.Enums.CardTimings.Action"/>
    /// </summary>
    /// <remarks>
    /// As you play this card, you may discard any number of cards from your hand.
    /// Draw cards equal to the number of cards discarded this way plus one.
    /// </remarks>
    [Serializable]
    public class Kourindou : SingleModeBaseMainCard, IActionMainTiming {
        public Kourindou(int id, ISeason season) : base(id,
            "Kourindou",
            season,
            3,
            new ActionKourindou()) { }
    }
}