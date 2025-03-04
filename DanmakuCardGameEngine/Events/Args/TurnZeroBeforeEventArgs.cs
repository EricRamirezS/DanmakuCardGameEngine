namespace DanmakuCardGameEngine.Events.Args {
    public class TurnZeroBeforeEventArgs : TurnZeroAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}