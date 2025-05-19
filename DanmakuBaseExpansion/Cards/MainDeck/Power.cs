using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using DanmakuCardGameEngine.Models.Cards.Type;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Power : SingleModeMainCard, IItemMainMode, IItemCard {
        public Power(int id, ISeason season) : base(id,
            "Power",
            season,
            2,
            new ItemPower()) { }
    }
}