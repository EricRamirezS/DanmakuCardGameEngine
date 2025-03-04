namespace DanmakuCardGameEngine.Events.Args {
    public class CardPlayedBeforeEventArgs : CardPlayedAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}