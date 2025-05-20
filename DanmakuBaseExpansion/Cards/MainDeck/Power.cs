using System;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using DanmakuCardGameEngine.Models.Cards.Type;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Power : SingleModeMainCard, IItemMainMode, IItemCard {
        public Power(int id, ISeason season) : base(id,
            "Power",
            season,
            2,
            new ItemPower()) { }
        
        public override IModifiers Modifiers => new Modifiers {
            new ModifierData(ModifierNames.AdditionalDanmaku, this, 1, Durations.Active),
            new ModifierData(ModifierNames.Range, this, 1, Durations.Active),
        };
    }
}