namespace DanmakuCG_Data.Models.Events.Args;

public class DeckShuffledBeforeEventArgs : DeckShuffledAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}