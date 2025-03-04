using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Kourindou : BaseMainCard {
        public Kourindou(string id, ISeason season) : base(id,
            "Kourindou",
            season,
            3) { }
    }
}