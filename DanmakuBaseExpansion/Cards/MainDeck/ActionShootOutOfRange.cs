using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    public class ActionShootOutOfRange : IActionAltMode {
        public IReadOnlyList<ICardSubtypes> AltCardTypes { get; }
        public void PlayAltMode() {
            throw new NotImplementedException();
        }

        public bool CanPlayAltMode() {
            throw new NotImplementedException();
        }
    }
}