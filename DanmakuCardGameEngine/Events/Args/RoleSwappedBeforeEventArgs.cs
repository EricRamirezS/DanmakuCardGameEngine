namespace DanmakuCG_Data.Models.Events.Args;

public class RoleSwappedBeforeEventArgs : RoleSwappedAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}