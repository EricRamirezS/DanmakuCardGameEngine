using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Shoot : BaseMainCard {
        public Shoot(string id, ISeason season) : base(id,
            "Shoot",
            season,
            1) { }
    }
}