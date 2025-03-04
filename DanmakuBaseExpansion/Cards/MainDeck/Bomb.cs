using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Bomb : BaseMainCard {
        public Bomb(string id, ISeason season) : base(
            id,
            "Bomb",
            season,
            4) { }
    }
}