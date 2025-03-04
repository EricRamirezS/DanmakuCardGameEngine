namespace DanmakuCG_Data.Models.Events.Args;

public class DanmakuPlayedBeforeEventArgs : DanmakuPlayedAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}