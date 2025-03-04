namespace DanmakuCG_Data.Models.Events.Args;

public class RoleRevealedBeforeEventArgs : RoleRevealedAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}