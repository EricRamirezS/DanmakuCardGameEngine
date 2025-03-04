namespace DanmakuCG_Data.Models.Events.Args;

public class AttackBeforeEventArgs : AttackAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}