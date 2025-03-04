namespace DanmakuCG_Data.Models.Events.Args;

public class IncreasedHealthBeforeEventArgs : IncreasedHealthAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}