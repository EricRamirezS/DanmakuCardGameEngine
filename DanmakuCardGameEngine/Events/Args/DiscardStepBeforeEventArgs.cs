namespace DanmakuCardGameEngine.Events.Args {
    public class DiscardStepBeforeEventArgs : DiscardStepAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}