namespace DanmakuCG_Data.Models.Events.Args;

public class DodgeBeforeEventArgs : DodgeAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}