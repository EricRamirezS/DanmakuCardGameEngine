using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class SorcerersSutraScroll : SingleModeMainCard, IItemMainMode {
        public SorcerersSutraScroll(int id, ISeason season) : base(id,
            "Sorcerer's Sutra Scroll",
            season,
            5,
            new ItemSorcerersSutraScroll()) { }
    }
}