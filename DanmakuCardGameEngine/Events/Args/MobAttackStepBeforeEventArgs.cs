namespace DanmakuCG_Data.Models.Events.Args;

public class MobAttackStepBeforeEventArgs : MobAttackStepAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}