using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using DanmakuCardGameEngine.Models.Cards.Type;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class SupernaturalBorder : SingleModeBaseMainCard, IItemMainTiming, IItemCard {
        public SupernaturalBorder(int id, ISeason season) : base(id,
            "Supernatural Border",
            season,
            3,
            new ItemSupernaturalBorder()) { }
    }
}