using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Melee : BaseMainCard {
        public Melee(string id, ISeason season) : base(id,
            "Melee",
            season,
            2) { }
    }
}