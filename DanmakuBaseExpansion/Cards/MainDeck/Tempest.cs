using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class SupernaturalBorder : BaseMainCard {
        public SupernaturalBorder(string id, ISeason season) : base(id,
            "Supernatural Border",
            season,
            3) { }
    }
}