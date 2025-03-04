using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Power : SingleModeMainCard, IItemMainMode {
        public Power(int id, ISeason season) : base(id,
            "Power",
            season,
            2,
            new ItemPower()) { }
    }
}