using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;
using CardSubtypes = DanmakuCardGameEngine.Enums.CardSubtypes;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    public class ItemFocus : IItemMainMode {
        public IReadOnlyList<ICardSubtypes> MainCardTypes => new List<ICardSubtypes> { CardSubtypes.Defense };

        public void PlayMainMode() {
            throw new System.NotImplementedException();
        }

        public bool CanPlayMainMode() {
            throw new System.NotImplementedException();
        }
    }
}