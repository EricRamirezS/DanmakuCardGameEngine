namespace DanmakuCardGameEngine.Events.Args {
    public class DrawStepBeforeEventArgs : DrawStepAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}