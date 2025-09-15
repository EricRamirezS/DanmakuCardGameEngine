using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    public class InvocationSpiritualAttack : IInvocationMainTiming {
        public IReadOnlyList<ICardSubtype> MainCardTypes { get; }
        public void PlayMainMode() {
            throw new NotImplementedException();
        }

        public bool CanPlayMainMode() {
            throw new NotImplementedException();
        }
    }
}