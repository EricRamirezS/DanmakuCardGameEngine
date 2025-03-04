using DanmakuCG_Data.Game;

namespace DanmakuCG_Data.Models.Events.Args;

public class TurnSkippedAfterEventArgs : BaseEventArgs {
    public ReadOnlyPlayer SkippingPlayer;
}