namespace DanmakuCardGameEngine.Events.Args {
    public class DanmakuPlayedBeforeEventArgs : DanmakuPlayedAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}