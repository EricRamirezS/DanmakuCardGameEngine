using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using DanmakuCardGameEngine.Tools;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    internal class ReactionBomb : IReactionAltTiming {
        public IReadOnlyList<ICardSubtypes> AltCardTypes => CardUtils.EmptySubtypes;

        public void PlayAltMode() {
            throw new NotImplementedException();
        }

        public bool CanPlayAltMode() {
            throw new NotImplementedException();
        }
    }
}