namespace DanmakuCardGameEngine.Events.Args {
    public class DeckShuffledBeforeEventArgs : DeckShuffledAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}