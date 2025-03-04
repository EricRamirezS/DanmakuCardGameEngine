using System;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class MiniHakkero : SingleModeMainCard, IItemMainMode  {
        public MiniHakkero(int id, ISeason season) : base(id,
            "Mini-Hakkero",
            season,
            5,
            new ItemMiniHakkero()) {
        }

        public override IModifiers Modifiers => new Modifiers {
            { ModifierNames.Range, new ModifierData(this, 3, Durations.Active)}
        };
    }
}