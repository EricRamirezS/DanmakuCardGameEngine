using DanmakuCG_Data.Game;
using DanmakuCG_Data.Models.Cards;

namespace DanmakuCG_Data.Models.Events.Args;

public class DiscardAfterEventArgs : BaseEventArgs {
    public Card[] Cards;
    public ReadOnlyPlayer DiscardedBy;
}