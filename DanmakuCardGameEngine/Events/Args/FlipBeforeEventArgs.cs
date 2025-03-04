namespace DanmakuCardGameEngine.Events.Args {
    public class FlipBeforeEventArgs : FlipAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}