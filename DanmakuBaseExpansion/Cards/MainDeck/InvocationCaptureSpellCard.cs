using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using DanmakuCardGameEngine.Tools;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    internal class InvocationCaptureSpellCard : IInvocationMainTiming {
        public IReadOnlyList<ICardSubtype> MainCardTypes => CardUtils.EmptySubtypes;
        public void PlayMainMode() {
            throw new NotImplementedException();
        }

        public bool CanPlayMainMode() {
            throw new NotImplementedException();
        }
    }
}