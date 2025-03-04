namespace DanmakuCardGameEngine.Events.Args {
    public class DecreasedHealthBeforeEventArgs : DecreasedHealthAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}