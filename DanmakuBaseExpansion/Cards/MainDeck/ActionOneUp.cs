using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using CardSubtypes = DanmakuCardGameEngine.Enums.CardSubtypes;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    class ActionOneUp : IActionMainMode {
        public IList<ICardSubtypes> MainCardTypes => new List<ICardSubtypes> { CardSubtypes.Healing };

        public void PlayMainMode() {
            throw new NotImplementedException();
        }

        public bool CanPlayMainMode() {
            throw new NotImplementedException();
        }
    }
}