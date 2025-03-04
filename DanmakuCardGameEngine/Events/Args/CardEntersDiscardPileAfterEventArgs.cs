using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Events.Args {
    public class CardEntersDiscardPileAfterEventArgs : BaseEventArgs {
        public IList<ICard> NewCards;
    }
}