using DanmakuCG_Data.Game;
using DanmakuCG_Data.Models.Cards;

namespace DanmakuCG_Data.Models.Events.Args;

public class DiscardBeforeEventArgs : DiscardAfterEventArgs, IBubbleEvent {
    public DiscardBeforeEventArgs() { }

    public DiscardBeforeEventArgs(Card[] cards, ReadOnlyPlayer discardedBy) {
        Cards = cards;
        DiscardedBy = discardedBy;
    }

    public bool BubbleEvent { get; set; } = true;
}