using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class Grimoire : SingleModeMainCard, IActionMainMode {
        public Grimoire(int id, ISeason season) : base(id, 
            "Grimoire", 
            season, 
            3,
            new ActionGrimoire()) { }
    }
}