namespace DanmakuCG_Data.Models.Events.Args;

public class CardPlayedBeforeEventArgs : CardPlayedAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}