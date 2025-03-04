namespace DanmakuCardGameEngine.Events.Args {
    public class IncidentResolvedBeforeEventArgs : IncidentResolvedAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}