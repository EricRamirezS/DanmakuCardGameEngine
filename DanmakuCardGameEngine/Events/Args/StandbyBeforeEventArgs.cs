namespace DanmakuCardGameEngine.Events.Args {
    public class StandbyBeforeEventArgs : StandbyAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}