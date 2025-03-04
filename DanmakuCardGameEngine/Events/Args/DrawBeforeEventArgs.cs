namespace DanmakuCG_Data.Models.Events.Args;

public class DrawBeforeEventArgs : DrawAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}