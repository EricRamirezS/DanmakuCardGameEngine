using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class SorcerersSutraScroll : BaseMainCard {
        public SorcerersSutraScroll(string id, ISeason season) : base(id,
            "Sorcerer's Sutra Scroll",
            season,
            5) { }
    }
}