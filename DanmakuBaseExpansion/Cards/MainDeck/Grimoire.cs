using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Grimoire : BaseMainCard {
        public Grimoire(string id, ISeason season) : base(id, 
            "Grimoire", 
            season, 
            3) { }
    }
}