using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using DanmakuCardGameEngine.Tools;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    public class ActionBorrow : IMainMode {
        public IReadOnlyList<ICardSubtypes> MainCardTypes => CardUtils.EmptySubtypes;

        public void PlayMainMode() {
            throw new NotImplementedException();
        }

        public bool CanPlayMainMode() {
            throw new NotImplementedException();
        }
    }
}