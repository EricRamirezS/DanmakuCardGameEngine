using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class SupernaturalBorder : SingleModeMainCard, IItemMainMode {
        public SupernaturalBorder(int id, ISeason season) : base(id,
            "Supernatural Border",
            season,
            3,
            new ItemSupernaturalBorder()) { }
    }
}