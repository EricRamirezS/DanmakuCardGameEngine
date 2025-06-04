using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using DanmakuCardGameEngine.Models.Cards.Type;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Stopwatch : SingleModeBaseMainCard, IItemMainTiming, IItemCard {
        public Stopwatch(int id, ISeason season) : base(id,
            "Stopwatch",
            season,
            5,
            new ItemStopwatch()) { }
        
          
        public override IModifiers Modifiers => new Modifiers {
            new ModifierData(ModifierNames.AdditionalDanmaku, this, 2, Durations.Active),
            new ModifierData(ModifierNames.Distance, this, 1, Durations.Active),
        };
    }
}