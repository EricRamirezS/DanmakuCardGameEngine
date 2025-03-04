namespace DanmakuCardGameEngine.Events.Args {
    public class DefeatBeforeEventArgs : DefeatAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}