namespace DanmakuCardGameEngine.Events.Args {
    public class EndOfTurnBeforeEventArgs : EndOfTurnAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}