using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class SpiritualAttack : BaseMainCard {
        public SpiritualAttack(string id, ISeason season) : base(id,
            "SpiritualAttack",
            season,
            3) { }
    }
}