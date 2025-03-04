using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Tempest : BaseMainCard {
        public Tempest(string id, ISeason season) : base(id,
            "Tempest",
            season,
            3) { }
    }
}