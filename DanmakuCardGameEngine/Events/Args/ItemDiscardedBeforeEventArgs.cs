namespace DanmakuCardGameEngine.Events.Args {
    public class ItemDiscardedBeforeEventArgs : ItemDiscardedAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}