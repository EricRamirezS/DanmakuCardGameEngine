using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class LaserShot : BaseMainCard {
        public LaserShot(string id, ISeason season) : base(id,
            "Laser Shot",
            season,
            4) { }
    }
}