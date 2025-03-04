namespace DanmakuCardGameEngine.Events.Args {
    public class NewIncidentBeforeEventArgs : NewIncidentAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}