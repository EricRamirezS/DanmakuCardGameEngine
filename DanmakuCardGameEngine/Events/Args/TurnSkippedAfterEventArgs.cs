using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    public class TurnSkippedAfterEventArgs : BaseEventArgs {
        public IReadOnlyPlayer SkippingPlayer;
    }
}