using DanmakuCardGameEngine.Game;

namespace DanmakuCardGameEngine.Events.Args {
    public class DrawStepAfterEventArgs : BaseEventArgs {
        public int CardsToDraw { get; }
    }
}