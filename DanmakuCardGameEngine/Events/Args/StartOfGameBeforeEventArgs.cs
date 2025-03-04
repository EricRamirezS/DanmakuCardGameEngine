namespace DanmakuCardGameEngine.Events.Args {
    public class StartOfGameBeforeEventArgs : StartOfGameAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}