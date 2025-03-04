namespace DanmakuCardGameEngine.Events.Args {
    public class RoleRevealedBeforeEventArgs : RoleRevealedAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}