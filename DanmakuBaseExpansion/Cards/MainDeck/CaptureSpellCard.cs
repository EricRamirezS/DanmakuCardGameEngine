using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class CaptureSpellCard : BaseMainCard {
        public CaptureSpellCard(string id, ISeason season) : base(
            id,
            "Capture Spell Card",
            season,
            4) { }
    }
}