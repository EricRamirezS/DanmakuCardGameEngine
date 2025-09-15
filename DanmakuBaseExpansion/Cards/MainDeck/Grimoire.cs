using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    /// <summary>
    /// <b>Grimoire</b><br/>
    /// <b>Deck:</b> Main deck<br/>
    /// <b>Point value:</b> 3<br/>
    /// <b>Card Types:</b> <see cref="DanmakuCardGameEngine.Enums.CardTimings.Action"/>
    /// </summary>
    /// <remarks>
    /// Draw two cards.
    /// </remarks>
    [Serializable]
    public class Grimoire : SingleModeBaseMainCard, IActionMainTiming {
        public Grimoire(int id, ISeason season) : base(id, 
            "Grimoire", 
            season, 
            3,
            new ActionGrimoire()) { }
    }
}