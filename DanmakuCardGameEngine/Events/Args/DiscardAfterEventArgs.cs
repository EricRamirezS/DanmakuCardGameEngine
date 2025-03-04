using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    public class DiscardAfterEventArgs : BaseEventArgs {
        public ICard[] Cards;
        public IReadOnlyPlayer DiscardedBy;
    }
}