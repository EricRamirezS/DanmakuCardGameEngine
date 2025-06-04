using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using DanmakuCardGameEngine.Models.Cards.Type;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class MiniHakkero : SingleModeBaseMainCard, IItemMainTiming, IItemCard {
        public MiniHakkero(int id, ISeason season) : base(id,
            "Mini-Hakkero",
            season,
            5,
            new ItemMiniHakkero()) { }

        public override IModifiers Modifiers => new Modifiers {
            new ModifierData(ModifierNames.Range, this, 3, Durations.Active),
        };
    }
}