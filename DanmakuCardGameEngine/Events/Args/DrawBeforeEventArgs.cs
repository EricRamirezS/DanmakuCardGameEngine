namespace DanmakuCardGameEngine.Events.Args {
    public class DrawBeforeEventArgs : DrawAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}