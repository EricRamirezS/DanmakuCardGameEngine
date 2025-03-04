namespace DanmakuCardGameEngine.Events.Args {
    public class TurnSkippedBeforeEventArgs : TurnSkippedAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}