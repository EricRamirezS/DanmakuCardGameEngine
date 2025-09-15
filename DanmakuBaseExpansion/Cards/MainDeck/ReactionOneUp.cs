using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using CardSubtypes = DanmakuCardGameEngine.Enums.CardSubtypes;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    internal class ReactionOneUp : IReactionAltTiming {
        public IReadOnlyList<ICardSubtype> AltCardTypes => new List<ICardSubtype> { CardSubtypes.Healing };

        public void PlayAltMode() {
            throw new NotImplementedException();
        }

        public bool CanPlayAltMode() {
            throw new NotImplementedException();
        }
    }
}