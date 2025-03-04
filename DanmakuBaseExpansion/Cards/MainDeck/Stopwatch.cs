using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Stopwatch : SingleModeMainCard, IItemMainMode {
        public Stopwatch(int id, ISeason season) : base(id,
            "Stopwatch",
            season,
            5,
            new ItemStopwatch()) { }
    }
}