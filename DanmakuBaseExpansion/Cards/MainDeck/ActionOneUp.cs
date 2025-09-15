using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using CardSubtypes = DanmakuCardGameEngine.Enums.CardSubtypes;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    internal class ActionOneUp : IActionMainTiming {
        public IReadOnlyList<ICardSubtype> MainCardTypes => new List<ICardSubtype> { CardSubtypes.Healing };

        public void PlayMainMode() {
            throw new NotImplementedException();
        }

        public bool CanPlayMainMode() {
            throw new NotImplementedException();
        }
    }
}