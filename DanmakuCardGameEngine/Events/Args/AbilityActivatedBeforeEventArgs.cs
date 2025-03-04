namespace DanmakuCardGameEngine.Events.Args {
    public class AbilityActivatedBeforeEventArgs : AbilityActivatedAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}