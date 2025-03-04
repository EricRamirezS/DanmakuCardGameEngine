namespace DanmakuCardGameEngine.Events.Args {
    public class CardsCollectedBeforeEventArgs : CardsCollectedAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}