namespace DanmakuCG_Data.Models.Events.Args;

public class HandRevealedBeforeEventArgs : HandRevealedAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}