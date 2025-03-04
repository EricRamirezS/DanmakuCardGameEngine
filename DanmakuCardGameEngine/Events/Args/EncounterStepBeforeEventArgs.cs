namespace DanmakuCardGameEngine.Events.Args {
    public class EncounterStepBeforeEventArgs : EncounterStepAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}