namespace DanmakuCG_Data.Models.Events.Args;

public class CardResolvedBeforeEventArgs : CardResolvedAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}