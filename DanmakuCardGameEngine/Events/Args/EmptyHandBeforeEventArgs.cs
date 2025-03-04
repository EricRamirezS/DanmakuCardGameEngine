namespace DanmakuCardGameEngine.Events.Args {
    public class EmptyHandBeforeEventArgs : EmptyHandAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}