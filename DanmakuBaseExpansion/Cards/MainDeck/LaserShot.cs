using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class LaserShot : SingleModeMainCard, IActionMainMode {
        public LaserShot(int id, ISeason season) : base(id,
            "Laser Shot",
            season,
            4,
            new ActionLaserShot()) { }
    }
}