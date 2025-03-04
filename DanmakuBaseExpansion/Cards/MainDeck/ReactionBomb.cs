using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    class ReactionBomb : IReactionAltMode {
        public IReadOnlyList<ICardSubtypes> AltCardTypes => new List<ICardSubtypes>();

        public void PlayAltMode() {
            throw new NotImplementedException();
        }

        public bool CanPlayAltMode() {
            throw new NotImplementedException();
        }
    }
}