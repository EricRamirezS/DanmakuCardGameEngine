using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using DanmakuCardGameEngine.Tools;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    internal class InvocationBomb : IInvocationMainTiming {
        public IReadOnlyList<ICardSubtypes> MainCardTypes => CardUtils.EmptySubtypes;

        public void PlayMainMode() {
            throw new System.NotImplementedException();
        }

        public bool CanPlayMainMode() {
            throw new System.NotImplementedException();
        }
    }
}