namespace DanmakuCG_Data.Models.Events.Args;

public class StartOfGameBeforeEventArgs : StartOfGameAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}