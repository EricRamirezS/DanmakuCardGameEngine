using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    /// <summary>
    /// <b>Laser Shot</b><br/>
    /// <b>Deck:</b> Main deck<br/>
    /// <b>Point value:</b> 4<br/>
    /// <b>Card Types:</b> <see cref="DanmakuCardGameEngine.Enums.CardTimings.Action"/>, <see cref="DanmakuCardGameEngine.Enums.CardSubtypes.Danmaku"/>
    /// </summary>
    /// <remarks>
    /// Attack a player, regardless of range. This attack cannot be avoided.<br/><br/>
    /// By default you can only play one <see cref="DanmakuCardGameEngine.Enums.CardSubtypes.Danmaku"/> card per round.
    /// </remarks>
    [Serializable]
    public class LaserShot : SingleModeBaseMainCard, IActionMainTiming {
        public LaserShot(int id, ISeason season) : base(id,
            "Laser Shot",
            season,
            4,
            new ActionLaserShot()) { }
    }
}