namespace DanmakuCardGameEngine.Events.Args {
    public class StartOfTurnBeforeEventArgs : StartOfTurnAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}