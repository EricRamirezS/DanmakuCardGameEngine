using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    public class DefeatAfterEventArgs : BaseEventArgs {
        public IPlayer DefeatedPlayer;
    }
}