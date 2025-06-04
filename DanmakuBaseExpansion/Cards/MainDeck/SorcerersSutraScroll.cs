using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using DanmakuCardGameEngine.Models.Cards.Type;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class SorcerersSutraScroll : SingleModeBaseMainCard, IItemMainTiming, IItemCard {
        public SorcerersSutraScroll(int id, ISeason season) : base(id,
            "Sorcerer's Sutra Scroll",
            season,
            5,
            new ItemSorcerersSutraScroll()) { }
        
          
        public override IModifiers Modifiers => new Modifiers {
            new ModifierData(ModifierNames.MaxHand, this, 3, Durations.Active),
            new ModifierData(ModifierNames.AdditionalDraw, this, 1, Durations.Active),
        };
    }
}