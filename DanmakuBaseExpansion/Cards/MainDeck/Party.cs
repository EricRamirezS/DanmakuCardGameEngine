using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class MiniHakkero : BaseMainCard {
        public MiniHakkero(string id, ISeason season) : base(id,
            "Mini-Hakkero",
            season,
            5) { }
    }
}