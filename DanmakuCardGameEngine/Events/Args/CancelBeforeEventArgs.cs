namespace DanmakuCG_Data.Models.Events.Args;

public class CancelBeforeEventArgs : CancelAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}