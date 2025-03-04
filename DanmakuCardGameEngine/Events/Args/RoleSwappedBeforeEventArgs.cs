namespace DanmakuCardGameEngine.Events.Args {
    public class RoleSwappedBeforeEventArgs : RoleSwappedAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}