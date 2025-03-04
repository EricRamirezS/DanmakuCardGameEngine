using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    public class DiscardBeforeEventArgs : DiscardAfterEventArgs, IBubbleEvent {
        public DiscardBeforeEventArgs() { }

        public DiscardBeforeEventArgs(ICard[] cards, IReadOnlyPlayer discardedBy) {
        Cards = cards;
        DiscardedBy = discardedBy;
    }

        public bool BubbleEvent { get; set; } = true;
    }
}