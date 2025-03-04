namespace DanmakuCardGameEngine.Events.Args {
    public class MainStepBeforeEventArgs : MainStepAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}