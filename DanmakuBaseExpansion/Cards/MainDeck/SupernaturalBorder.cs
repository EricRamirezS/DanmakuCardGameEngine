using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Stopwatch : BaseMainCard {
        public Stopwatch(string id, ISeason season) : base(id,
            "Stopwatch",
            season,
            5) { }
    }
}