using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class CaptureSpellCard : SingleModeMainCard, IInvocationMainMode {
        public CaptureSpellCard(int id, ISeason season) : base(
            id,
            "Capture Spell Card",
            season,
            4,
            new InvocationCaptureSpellCard()) { }
    }
}