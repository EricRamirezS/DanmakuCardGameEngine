using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Party : BaseMainCard {
        public Party(string id, ISeason season) : base(id,
            "Party",
            season,
            3) { }
    }
}