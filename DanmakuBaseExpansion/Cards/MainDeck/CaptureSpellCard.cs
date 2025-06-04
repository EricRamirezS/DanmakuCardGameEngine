using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class CaptureSpellCard : SingleModeBaseMainCard, IInvocationMainTiming {
        public CaptureSpellCard(int id, ISeason season) : base(
            id,
            "Capture Spell Card",
            season,
            4,
            new InvocationCaptureSpellCard()) { }
    }
}