using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class SealAway : BaseMainCard {
        public SealAway(string id, ISeason season) : base(id,
            "Seal Away",
            season,
            2) { }
    }
}