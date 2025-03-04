namespace DanmakuCardGameEngine.Events.Args {
    public class StackResolvedBeforeEventArgs : StackResolvedAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}