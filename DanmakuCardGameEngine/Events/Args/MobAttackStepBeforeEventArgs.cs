namespace DanmakuCardGameEngine.Events.Args {
    public class MobAttackStepBeforeEventArgs : MobAttackStepAfterEventArgs, IBubbleEvent {
        public bool BubbleEvent { get; set; } = true;
    }
}