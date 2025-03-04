namespace DanmakuCG_Data.Models.Events.Args;

public class HandSwappedBeforeEventArgs : HandSwappedAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}