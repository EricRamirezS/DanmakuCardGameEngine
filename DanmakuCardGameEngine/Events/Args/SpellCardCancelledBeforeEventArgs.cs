namespace DanmakuCG_Data.Models.Events.Args;

public class SpellCardCancelledBeforeEventArgs : SpellCardCancelledAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}