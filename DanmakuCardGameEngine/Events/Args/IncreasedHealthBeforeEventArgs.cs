namespace DanmakuCardGameEngine.Events.Args {
    public class IncreasedHealthBeforeEventArgs : IncreasedHealthAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}