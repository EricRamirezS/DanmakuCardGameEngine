namespace DanmakuCardGameEngine.Events.Args {
    public class CardResolvedBeforeEventArgs : CardResolvedAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}