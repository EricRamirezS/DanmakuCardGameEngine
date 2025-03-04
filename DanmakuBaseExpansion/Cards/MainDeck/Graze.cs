using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Graze : BaseMainCard {
        public Graze(string id, ISeason season) :
            base(id,
                "Graze",
                season,
                1) { }
    }
}